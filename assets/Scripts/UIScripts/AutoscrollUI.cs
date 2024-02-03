using UnityEngine;
using UnityEngine.UIElements;

public class AutoscrollUI : MonoBehaviour
{
    public float waitTime = 2f;
    public float scrollSpeed = 0.1f;
    VisualElement root, container;

    private bool isScrolling = false;
    private float offset = 0f;

    private void OnEnable() {
        root = GetComponent<UIDocument>().rootVisualElement;
        container = root.Q<VisualElement>("Container");
        Invoke(nameof(EnableScroll), waitTime);
    }

    private void EnableScroll() {
        isScrolling = true;
    }

    private void Update() {
        if (isScrolling) {
            // calculate heights of screen and container element
            float rootHeight = root.resolvedStyle.height;
            float containerHeight = container.resolvedStyle.height;

            // determine if more scrolling has to be done
            if (rootHeight + offset < containerHeight) {
                offset+= scrollSpeed;
                container.style.top = -offset;
            } else {
                isScrolling = false;
            }
        }
    }
}
