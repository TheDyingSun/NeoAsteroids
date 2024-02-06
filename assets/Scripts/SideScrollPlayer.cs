using UnityEngine;
using UnityEngine.UI;

public class SideScrollPlayer : MonoBehaviour{

    public Bullet bulletPrefab;

    private float verticalSpeed;
    private float turnDirection;
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
    }

    private void Update(){
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            //Turning Left
            turnDirection = 1.0f;
            Debug.Log("Turning Left");
            

        } else  if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            //Turning Right
            turnDirection = -1.0f;
            Debug.Log("Turning Right");
        } else {
            turnDirection = 0.0f;
        }

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
            verticalSpeed = -2.0f;
            Debug.Log("Moving Up");

        } else  if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
            verticalSpeed = 2.0f;
            Debug.Log("Moving Down");
        } else {
            verticalSpeed = 0.0f;
        }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            Shoot();
        }



    }

    private void FixedUpdate(){
        if (verticalSpeed != 0f) {
            _rigidBody.AddForce(Vector2.down * verticalSpeed, ForceMode2D.Force);
        }

        // if(turnDirection != 0f){
        //     //_rigidBody.AddTorque(turnSpeed * turnDirection, ForceMode2D.Impulse);
        //     limRotation();
        // }

    }

    private void Shoot(){
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up, _rigidBody.velocity);

    }

    private void limRotation() {
        //Code from: https://www.youtube.com/watch?v=dU_6Z3WKdtg 
        Vector3 eulerAngles = this.transform.eulerAngles;
        eulerAngles.z = (eulerAngles.z < 180) ? eulerAngles.z - 360 : eulerAngles.z;
        eulerAngles.z += turnSpeed * turnDirection * 10;
        eulerAngles.z = Mathf.Clamp(eulerAngles.z, 180f, 359f);
        // Debug.Log("Current eulerAngle.z: " + eulerAngles.z);
        this.transform.rotation = Quaternion.Euler(eulerAngles);
    }

    // private void limRot2(){
    //     float currentRot = _rigidBody.rotation;
    //     Debug.Log("In limit rotation, current rotation: " + currentRot);
    //     if (currentRot > 0f || currentRot < -180f) {
    //         Debug.Log("Rotation limit reached");
    //         _rigidBody.angularDrag = 100000f;
    //     }
    // }

}
