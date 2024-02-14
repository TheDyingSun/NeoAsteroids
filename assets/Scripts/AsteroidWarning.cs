using UnityEngine;

public class AsteroidWarning : MonoBehaviour
{
    Animator animator;
    Transform parentAsteroid;

    public void Start() {
        animator = GetComponent<Animator>();
        animator.SetBool("animating", true);
    }

    public void Point(Transform parent, Vector2 direction) {
        // get screen bounds in world coordinates
        Vector3 topLeft = Camera.main.ScreenToWorldPoint(Vector2.zero);
        Vector3 bottomRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        // calculate the time at which the asteroid will cross each screen bound
        float ty1 = (topLeft.y - parent.position.y) / direction.y;
        float ty2 = (bottomRight.y - parent.position.y) / direction.y;
        float tx1 = (topLeft.x - parent.position.x) / direction.x;
        float tx2 = (bottomRight.x - parent.position.x) / direction.x;

        // find time when it will enter screen, use it to calculate its x and y
        float ta = Mathf.Max(Mathf.Min(ty1, ty2), Mathf.Min(tx1, tx2));
        float ya = ta*direction.y + parent.position.y;
        float xa = ta*direction.x + parent.position.x;

        // set position to that x and y
        transform.position = new Vector3(xa * 0.9f, ya * 0.8f, 0f);

        // rotate arc so it's facing the asteroid
        Transform arc = transform.Find("Arc");
        arc.LookAt(parent);
        arc.Rotate(new Vector3(0f, 90f, 90f));

        parentAsteroid = parent;
    }

    private void Update() {
        float dist = 0f;
        if (parentAsteroid != null) {
            dist = Vector3.Distance(transform.position, parentAsteroid.position);
        }

        // remove warning if asteroid is destroyed or close to entering screen
        if (parentAsteroid == null || dist < 3f) {
            animator.SetBool("animating", false);
            Invoke(nameof(Remove), 2f);
        }
    }

    private void Remove() {
        Destroy(gameObject);
    }
}
