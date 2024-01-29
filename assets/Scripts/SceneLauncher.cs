using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLauncher : MonoBehaviour
{
    public void Play() {
        SceneManager.LoadScene(sceneName:"LevelSelection");
    }

    public void Initial_Build() {
        SceneManager.LoadScene(sceneName:"Asteroids (Old)");
    }

    public void Credits() {
        SceneManager.LoadScene(sceneName:"Credits");
    }

    public void Version_Notes() {
        SceneManager.LoadScene(sceneName:"Version Notes");
    }
}
