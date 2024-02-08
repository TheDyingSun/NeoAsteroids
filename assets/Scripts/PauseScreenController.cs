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
            Time.timeScale = 0f;
            this.pauseScreen.gameObject.SetActive(true);
        }
    }

    private bool togglePause() {
		if(Time.timeScale == 0f) {
			Time.timeScale = 1f;
			return(false);
		} else {
			Time.timeScale = 0f;
			return(true);	
		}
	}
    

    // Update is called once per frame
    
}
