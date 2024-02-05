using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour{

    public Bullet bulletPrefab;
    public Image ZoomingImage;

    private bool _thrusting;
    private float turnDirection;

    public float thrustSpeed = 1.0f;
    public float turnSpeed = 1.0f;

    private Rigidbody2D _rigidBody;
    public SpriteRenderer spriteRenderer;
    public AudioClip damageClip;

    public Color defaultCol;
    public Color respawnColor;

    public Animator animator;

    private void Awake(){
        _rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = defaultCol;
        animator = GetComponent<Animator>();
        if (ZoomingImage) {
            ZoomingImage.color = new Color(255, 255, 255, 0);
        }
    }

    private void Update(){
        _thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            turnDirection = 1.0f;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            turnDirection = -1.0f;
        } else {
            turnDirection = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            Shoot();
        }
    }

    private void FixedUpdate(){
        if (_thrusting){  _rigidBody.AddForce(this.transform.up * this.thrustSpeed, ForceMode2D.Force); }
        if (turnDirection != 0f){ _rigidBody.AddTorque(turnSpeed * turnDirection, ForceMode2D.Force); }
    }

    private void Shoot(){
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        Debug.Log(this.transform.up.magnitude);
        Debug.Log(_rigidBody.velocity.magnitude);
        bullet.Project(this.transform.up, _rigidBody.velocity);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Asteroid"){
            _rigidBody.velocity = Vector3.zero;
            _rigidBody.angularVelocity = 0.0f;
            AudioManager.instance.PlayClip(damageClip, transform, 1f);
            FindObjectOfType<GameManager>().PlayerDied();
        }

        if (collision.gameObject.tag == "Right Boundary" && ZoomingImage) {
            ZoomingImage.color = new Color(255, 255, 255, 1);
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Right Boundary" && ZoomingImage) {
            ZoomingImage.color = new Color(255, 255, 255, 0);
        }
    }

}
