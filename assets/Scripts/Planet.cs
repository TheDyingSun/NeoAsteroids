using UnityEngine;

public class Planet : MonoBehaviour
{
    public Sprite[] sprites;
    public float rotationSpeed = 0f;
    private Vector3 velocity = new Vector3(0f, 0f, 0f);
    private SpriteRenderer spriteRenderer;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // perform rotation and translation
        transform.Rotate(new Vector3(0f, 0f, rotationSpeed));
        transform.position += velocity;
    }

    // randomly set position, rotation, and velocity (but keep sprite constant)
    public void setStatic(int spriteIndex) {
        velocity = new Vector3(
            Random.Range(-0.00003f, 0.00003f),
            Random.Range(-0.00003f, 0.00003f), 0f );
        transform.position = new Vector3(
            Random.Range(-3f, 3f),
            Random.Range(-2f, 2f), 0f );
        transform.localScale = new Vector3(0.35f, 0.35f, 1f);
        rotationSpeed = Random.Range(-0.003f, 0.003f);
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    public void setSidescroll(int spriteIndex) {
        velocity = new Vector3(-0.001f, Random.Range(-0.0002f, 0.0002f), 0f);
        transform.position = new Vector3(16f, Random.Range(-1f, 1f), 0f);
        transform.localScale = new Vector3(0.7f, 0.7f, 1f);
        rotationSpeed = Random.Range(-0.003f, 0.003f);
        spriteRenderer.sprite = sprites[spriteIndex];
    }
}
