using UnityEngine;

public class Bullet_old : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidBody;

    public float speed = 500.0f;

    public float maxLifetime = 10.0f;

    private void Awake(){
        rigidBody = GetComponent<Rigidbody2D>();

    }

    public void Project(Vector2 direction){

        rigidBody.AddForce(direction * this.speed);

        Destroy(this.gameObject, this.maxLifetime);

    }

    private void OnCollisionEnter2D(Collision2D collision){
        Destroy(this.gameObject);

    }

}
