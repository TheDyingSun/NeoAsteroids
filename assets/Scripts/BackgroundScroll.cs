using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Code from this video: https://www.youtube.com/watch?v=-6H-uYh80vc 

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] private RawImage img;
    [SerializeField] private float x, y;
    [SerializeField] private float speed = 0.1f;
    void Update()
    {
        img.uvRect = new Rect(img.uvRect.position + new Vector2(x, y) * Time.deltaTime * speed, img.uvRect.size);
    }

}
