using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneRenderer : MonoBehaviour
{
    // Start is called before the first frame update

    public Sprite[] sprites;
    private SpriteRenderer spriteRender;


    void OnEnable(){
        spriteRender = GetComponent<SpriteRenderer>();
        spriteRender.sprite = sprites[1];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
