using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialougeManager : MonoBehaviour{

    public DialogueRunner dialogueRunner;
    
    
    // Start is called before the first frame update
    public void Start() {

        switch(SceneStateManager.currentLevel){
            case CurrentLevel.Introduction:
                dialogueRunner.StartDialogue("Introduction");
            break;

            case CurrentLevel.FirstCutScene: 
                dialogueRunner.StartDialogue("PostIntro");

            break;

            case CurrentLevel.SecondCutScene: // Yar intro
                dialogueRunner.StartDialogue("YarIntroduction");
            break;

            case CurrentLevel.ThirdCutScene: // Brough Intro
                dialogueRunner.StartDialogue("BroughIntroduction");
            break;

            case CurrentLevel.FourthCutScene: // You have to choose
                dialogueRunner.StartDialogue("TheDecision");
            break;

            case CurrentLevel.FinalCutScene:
                if(SceneStateManager.YarChosen){
                    dialogueRunner.StartDialogue("YarEnding");
                } else {
                    dialogueRunner.StartDialogue("BroughEnding");
                }


            break;



        }

        
    }

}
