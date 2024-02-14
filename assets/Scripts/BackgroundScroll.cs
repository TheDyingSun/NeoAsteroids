using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Code from this video: https://www.youtube.com/watch?v=-6H-uYh80vc 

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] private RawImage img;
    [SerializeField] private float x, y;
    void Update()
    {
        img.uvRect = new Rect(img.uvRect.position + new Vector2(x, y) * Time.deltaTime, img.uvRect.size);
    }

}
