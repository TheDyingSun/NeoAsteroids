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
        Invoke(nameof(removeOpaqueClass), 0.2f);
    }

    public void removeOpaqueClass() {
        container.RemoveFromClassList("opaque");
    }
 
    public void fadeOut() {
        container.AddToClassList("opaque");
    }
}
