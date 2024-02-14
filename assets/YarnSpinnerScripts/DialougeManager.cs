using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialougeManager : MonoBehaviour{

    public DialogueRunner dialogueRunner;
    
    
    // Start is called before the first frame update
    public void OnEnable() {

        StartCoroutine(ExampleCoroutine());
    dialogueRunner.StartDialogue("Introduction");

        
    }

    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

}
