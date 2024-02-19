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

    void Start()
    {
        setStatic(0); // remove once scene manager is set up
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
}
