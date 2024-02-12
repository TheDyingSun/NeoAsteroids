using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer spriteRender;
    private Rigidbody2D rigidBody;
    public AudioClip damageClip;
    public AsteroidWarning warningPrefab;

    public float maxSize = 1.5f;
    public float minSize = 0.75f;
    public float size = 1.0f;
    public float speed = 25.0f;
    public float weightOffset = 2.5f;
    public float maxLifetime = 30.0f;

    private bool child = false;

    private void Awake(){
        spriteRender = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start(){
        spriteRender.sprite = sprites[Random.Range(0, sprites.Length - 1)];

        this.transform.eulerAngles = new Vector3(0f,0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;
        this.enabled = false;
    }
    
    public void SetTrajectory(Vector2 direction){
        rigidBody.mass = this.size + this.weightOffset;
        rigidBody.AddForce(direction * this.speed);
        this.enabled = true;
        Destroy(this.gameObject, this.maxLifetime);

        if (!child) {
            AsteroidWarning warning = Instantiate(warningPrefab);
            warning.Point(transform, direction);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        //if colliding with bullet
        if(collision.gameObject.tag == "Bullet"){
            this.enabled = false;
            if((this.size/2) >= minSize){
                //Split into 2
                CreateSplit();
                CreateSplit();
            }

            AudioManager.instance.PlayClip(damageClip, transform, 1f);
            FindObjectOfType<GameManager>().AsteroidDestroyed(this);
            Destroy(this.gameObject);
        }
    }

    private void CreateSplit(){
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;

        Asteroid half = Instantiate(this, position, this.transform.rotation);
        half.child = true;
        half.size = this.size * 0.5f;
        half.SetTrajectory(Random.insideUnitCircle.normalized);
    }
}
