using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStateManager : MonoBehaviour{
    public static string currentStage = "Debug Text";

    public static void ChangeCurrentStage(string input){

        currentStage = input;

    }

}
