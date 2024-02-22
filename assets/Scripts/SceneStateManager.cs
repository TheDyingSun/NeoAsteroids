using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateManager : MonoBehaviour{
    public static string currentStage = "Debug Text";

    public static bool arcadeMode = false;

    public bool ChoseYar = true; //Choosing yar is the default
    public static CurrentLevel currentLevel = CurrentLevel.Introduction;


    public static void ChangeCurrentStage(string input){

        currentStage = input;

    }


    public static void NextLevel(){
        if(arcadeMode){
            SceneManager.LoadScene(sceneName:"LevelSelection");

        } else {

        currentLevel++;

            if(currentLevel == CurrentLevel.Introduction || currentLevel == CurrentLevel.FirstCutScene || currentLevel == CurrentLevel.SecondCutScene || 
            currentLevel == CurrentLevel.ThirdCutScene || currentLevel == CurrentLevel.FourthCutScene){
                SceneManager.LoadScene(sceneName:"CutScene");
            }

            if(currentLevel == CurrentLevel.IntroStatic || currentLevel == CurrentLevel.SecondStatic || currentLevel == CurrentLevel.FourthStatic){
                SceneManager.LoadScene(sceneName:"Asteroids");
            }

            if(currentLevel == CurrentLevel.FirstSideScroll || currentLevel == CurrentLevel.ThirdSideScroll){
                SceneManager.LoadScene(sceneName:"SideScroll");
            }

            if(currentLevel == CurrentLevel.FinalCutScene){
                SceneManager.LoadScene(sceneName:"Credits");
            }

        }

    }
}

public enum CurrentLevel {
    Introduction,
    FirstLevel,
    FirstCutScene,    // Space Commendation
    SecondLevel,
    SecondCutScene,   // Meeting the Yar
    ThirdLevel,
    ThirdCutScene,    // Meeting the Brough
    FourthLevel,
    FourthCutScene,   // You have to pick
    FifthLevelYar,
    FifthLevelBrough,
    FinalCutScene     // Thank you for playing
}
