using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitHandler : MonoBehaviour
{
    public string targetName;
    void Update()
    {  
        if (Input.GetKey("escape")) {
            SceneManager.LoadScene(sceneName:targetName);
        }
    }
}
