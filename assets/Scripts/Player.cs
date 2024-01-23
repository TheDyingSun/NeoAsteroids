using UnityEngine;

public class Player : MonoBehaviour{

    public Bullet bulletPrefab;

    private bool _thrusting;
    private float turnDirection;

    public float thrustSpeed = 1.0f;
    public float turnSpeed = 1.0f;

    private Rigidbody2D _rigidBody;
    public SpriteRenderer spriteRenderer;

    public Color defaultCol;

    public Color respawnColor;

    public Animator animator;

    private void Awake(){
        _rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = defaultCol;
        animator = GetComponent<Animator>();
    }

    private void Update(){
        _thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        if(_thrusting){Debug.Log("Thrust given");}


        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            //Turning Left
            turnDirection = 1.0f;
            Debug.Log("Turning Left");
            

        } else  if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            //Turning Left
            turnDirection = -1.0f;
            Debug.Log("Turning Right");
        } else {
            turnDirection = 0.0f;
        }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            Shoot();
        }



    }

    private void FixedUpdate(){
        // I accidentally misspelled the name of this Method and was debugging for an hour
        //Debug.Log("Updating");
        if(_thrusting){
            _rigidBody.AddForce(this.transform.up * this.thrustSpeed, ForceMode2D.Force);

        }

        if(turnDirection != 0f){

            _rigidBody.AddTorque(turnSpeed * turnDirection, ForceMode2D.Force);

        }

    }

    private void Shoot(){
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up);

    }

    private void OnCollisionEnter2D(Collision2D collision){

        if (collision.gameObject.tag == "Asteroid"){
            _rigidBody.velocity = Vector3.zero;
            _rigidBody.angularVelocity = 0.0f;
            FindObjectOfType<GameManager>().PlayerDied();
        }

    }

}
