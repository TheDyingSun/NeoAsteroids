using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateManager : MonoBehaviour{
    public static string currentStage = "Debug Text";


    public static void ChangeCurrentStage(string input){

        currentStage = input;

    }


    public static void NextLevel(){

        SceneManager.LoadScene(sceneName:"MainMenu");

    }

}

public enum CurrentLevel{
    Introduction = 0,
    IntroStatic = 1,
    FirstCutScene = 2, //Space Commendation
    FirstSideScroll = 3,
    SecondCutScene, // Meeting the Yar
    SecondStatic,
    ThirdCutScene, // Meeting the Brough
    ThirdSideScroll,
    FourthCutScene, // You have to pick
    FourthStatic,
    FinalCutScene   //Thank you for playing

}
