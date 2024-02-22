using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialougeManager : MonoBehaviour{

    public DialogueRunner dialogueRunner;
    
    
    // Start is called before the first frame update
    public void OnEnable() {

        dialogueRunner.StartDialogue("Introduction");

        
    }

}
