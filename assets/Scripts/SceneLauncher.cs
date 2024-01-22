using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLauncher : MonoBehaviour
{
    public void Play() {
        SceneManager.LoadScene(sceneName:"Asteroids");
    }

    public void Initial_Build() {
        SceneManager.LoadScene(sceneName:"Asteroids (Old)");
    }
}
