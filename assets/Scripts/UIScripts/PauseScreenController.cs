using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreenController : MonoBehaviour
{
    
    public PauseScreen pauseScreen;


    private void OnEnable(){

        //Input.GetKey("escape").
        

    }
    
    private void Update() {
        if (Input.GetKey("escape") || Input.GetKey(KeyCode.N)) {
            this.pauseScreen.gameObject.SetActive(true);
            
        }
    }
    

    // Update is called once per frame
    
}
