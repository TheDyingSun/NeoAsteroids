using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateManager : MonoBehaviour{
    public static CurrentLevel currentLevel = CurrentLevel.Introduction;
    public static bool arcadeMode = false;

    public static bool YarChosen = true;


    public static void ChangeCurrentStage(string input){

        //currentStage = input;

    }


    public static void NextLevel(){

        if(arcadeMode){
            SceneManager.LoadScene(sceneName:"MainMenu");

        } else {
            currentLevel++;

            if(currentLevel == CurrentLevel.Introduction || currentLevel == CurrentLevel.FirstCutScene || currentLevel == CurrentLevel.SecondCutScene || currentLevel == CurrentLevel.ThirdCutScene || currentLevel == CurrentLevel.FourthCutScene || currentLevel == CurrentLevel.FinalCutScene){
                SceneManager.LoadScene(sceneName:"CutScene");

            } else if(currentLevel == CurrentLevel.IntroStatic || currentLevel == CurrentLevel.SecondStatic || currentLevel == CurrentLevel.FourthStatic){
                //Static
                SceneManager.LoadScene(sceneName:"Asteroids");

            } else if(currentLevel == CurrentLevel.FirstSideScroll || currentLevel == CurrentLevel.ThirdSideScroll){
                //Sidescroller
                SceneManager.LoadScene(sceneName:"SideScroller");
            }




        }


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
