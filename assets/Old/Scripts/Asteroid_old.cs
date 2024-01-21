using UnityEngine;

public class Asteroid_old : MonoBehaviour
{

    public Sprite[] sprites;
    private SpriteRenderer spriteRender;
    private Rigidbody2D rigidBody;


    public float maxSize = 1.5f;
    public float minSize = 0.5f;

    public float size = 1.0f;

    public float speed = 50.0f;

    public float weightMultipler = 2.5f;

    public float maxLifetime = 30.0f;

    private void Awake(){

        spriteRender = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
        
    }

    private void Start(){
        spriteRender.sprite = sprites[Random.Range(0, sprites.Length - 1)];

        this.transform.eulerAngles = new Vector3(0f,0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;

        rigidBody.mass = this.size * weightMultipler;
    }
    
    public void SetTrajectory(Vector2 direction){
        rigidBody.AddForce(direction * this.speed);

        Destroy(this.gameObject, this.maxLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        //if colliding with bullet
        if(collision.gameObject.tag == "Bullet"){
            if((this.size/2) >= minSize){
                //Split into 2

                CreateSplit();
                CreateSplit();

                
            }

            FindObjectOfType<GameManager_old>().AsteroidDestroyed(this);
            Destroy(this.gameObject);
            

        }

    }

    private void CreateSplit(){

        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;

        
        Asteroid_old half = Instantiate(this, position, this.transform.rotation);
        half.size = this.size * 0.5f;
        half.SetTrajectory(Random.insideUnitCircle.normalized * this.speed);

    }


}
