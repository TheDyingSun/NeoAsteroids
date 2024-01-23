using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitHandler : MonoBehaviour
{
    void Update()
    {  
        if (Input.GetKey("escape")) {
            SceneManager.LoadScene(sceneName:"Main Menu");
        }
    }
}
