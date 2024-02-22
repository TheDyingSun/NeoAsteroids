using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class SideScrollPlayer : MonoBehaviour{

    public Bullet bulletPrefab;

    private float verticalVelocity;
    public float verticalAccel;
    private float angle;
    private float turnVelocity;
    public float turnAccel;
    public float verticalVelocityCap = 0.1f;
    public float turnVelocityCap = 5f;

    private Rigidbody2D _rigidBody;
    public SpriteRenderer spriteRenderer;
    public AudioClip damageClip;

    public Color defaultCol;

    public Color respawnColor;

    public Animator animator;

    private float lastBulletFire = 0f;
    public float bulletCooldown = 0.15f;

    private void Awake(){
        _rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = defaultCol;
        animator = GetComponent<Animator>();
    }

    private void Update(){
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            turnVelocity = Mathf.Min(turnVelocity + turnAccel * Time.deltaTime * 100, turnVelocityCap * 100);
        } else  if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            turnVelocity = Mathf.Max(turnVelocity - turnAccel * Time.deltaTime * 100, -turnVelocityCap * 100);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
            verticalVelocity = Mathf.Min(verticalVelocity + verticalAccel * Time.deltaTime, verticalVelocityCap);
        } else  if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            verticalVelocity = Mathf.Max(verticalVelocity - verticalAccel * Time.deltaTime, -verticalVelocityCap);
        }

        // handle bullet firing
        lastBulletFire += Time.deltaTime;
        bool tryingToFire = Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);
        bool canFire = lastBulletFire > bulletCooldown;
        if (tryingToFire && canFire) {
            lastBulletFire = 0f;
            Shoot();
        }
        float newY = transform.position.y + verticalVelocity * Time.deltaTime;
        if (Mathf.Abs(newY) > 4f) {
            newY = Mathf.Clamp(newY, -4f, 4f);
            verticalVelocity = 0f;

        }
        transform.position = new Vector3(-5f, newY, 0f);

        angle += turnVelocity * Time.deltaTime;
        Debug.Log(angle);
        if (angle > 0f || angle < -180f) {
            angle = Mathf.Clamp(angle, -180f, 0f);
            turnVelocity = 0f;
        }
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        verticalVelocity *= 0.999f;
        turnVelocity *= 0.999f;
    }

    private void Shoot(){
        if (Time.timeScale != 0f) {
            Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
            bullet.Project(this.transform.up, _rigidBody.velocity); 
        }
    }
}
