using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;

public class YarnCommands : MonoBehaviour
{
    [YarnCommand("fade_camera")]
    public static void FadeCamera() {
        Debug.Log("Fading the camera!");
    }
    
    [YarnCommand("kickPlayerOut")]
    public static void ExitToLevelSelector() {
       SceneManager.LoadScene(sceneName:"LevelSelection");
    }
}
