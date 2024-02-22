using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateManager : MonoBehaviour {
    public static CurrentLevel currentLevel = CurrentLevel.Introduction;
    public static SceneStateManager instance;

    public static void NextLevel() {
        switch (currentLevel) {
            case CurrentLevel.Introduction:
                currentLevel = CurrentLevel.FirstLevel;
                SceneManager.LoadScene(sceneName:"Asteroids");
                break;
            case CurrentLevel.FirstLevel:
                currentLevel = CurrentLevel.FirstCutScene;
                SceneManager.LoadScene(sceneName:"CutScene");
                break;
            case CurrentLevel.FirstCutScene:
                currentLevel = CurrentLevel.SecondLevel;
                SceneManager.LoadScene(sceneName:"SideScroller");
                break;
            case CurrentLevel.SecondLevel:
                currentLevel = CurrentLevel.SecondCutScene;
                SceneManager.LoadScene(sceneName:"CutScene");
                break;
            case CurrentLevel.SecondCutScene:
                currentLevel = CurrentLevel.ThirdLevel;
                SceneManager.LoadScene(sceneName:"Asteroids");
                break;
            case CurrentLevel.ThirdLevel:
                currentLevel = CurrentLevel.ThirdCutScene;
                SceneManager.LoadScene(sceneName:"CutScene");
                break;
            case CurrentLevel.ThirdCutScene:
                currentLevel = CurrentLevel.FourthLevel;
                SceneManager.LoadScene(sceneName:"SideScroller");
                break;
            case CurrentLevel.FourthLevel:
                currentLevel = CurrentLevel.FourthCutScene;
                SceneManager.LoadScene(sceneName:"CutScene");
                break;
            case CurrentLevel.FifthLevelYar:
                currentLevel = CurrentLevel.FinalCutScene;
                SceneManager.LoadScene(sceneName:"SideScroller");
                break;
            case CurrentLevel.FifthLevelBrough:
                currentLevel = CurrentLevel.FinalCutScene;
                SceneManager.LoadScene(sceneName:"SideScroller");
                break;
            case CurrentLevel.FinalCutScene:
                currentLevel = CurrentLevel.Introduction;
                SceneManager.LoadScene(sceneName:"Credits");
                break;
        }
    }

    public static void ContinueToYar() {
        currentLevel = CurrentLevel.FifthLevelYar;
        SceneManager.LoadScene(sceneName:"Asteroids");
    }

    public static void ContinueToBrough() {
        currentLevel = CurrentLevel.FifthLevelBrough;
        SceneManager.LoadScene(sceneName:"Asteroids");
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
