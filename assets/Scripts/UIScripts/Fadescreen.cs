using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Fadescreen : MonoBehaviour {
    VisualElement root;
    VisualElement container;
 
    void OnEnable() {
        root = GetComponent<UIDocument>().rootVisualElement;
        container = root.Q("container");
    }

    public void fadeIn() {
        OnEnable();
        Debug.Log("Fading in");
        fade(0);
    }
 
    public void fadeOut() {
        OnEnable();
        Debug.Log("Fading out");
        fade(1);
    }
    private void fade(float target) {
        container.style.opacity = target;
        container.style.transitionProperty = new List<StylePropertyName> { "opacity" };
        container.style.transitionDuration = new List<TimeValue> { new TimeValue(1f, TimeUnit.Second) };
        container.style.transitionTimingFunction = new List<EasingFunction> { EasingMode.Ease };
    }
}
