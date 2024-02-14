using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour{

    VisualElement root;
    Button restartButton, returnToMenuButton, exitGameButton, resumeButton;
    // Start is called before the first frame update

    public ConfirmExitScreen confirmExitScreen;
    //Button btn = yourButton.GetComponent<Button>();
		
    
    void OnEnable(){

        root = GetComponent<UIDocument>().rootVisualElement;
        
        restartButton = root.Q<Button>("RestartLevelButton");
        returnToMenuButton = root.Q<Button>("MainMenuButton");
        exitGameButton = root.Q<Button>("ExitGameButton");
        resumeButton = root.Q<Button>("ResumeButton");


        //Setup eventlisteners
        returnToMenuButton.clicked += () => ExitToMainMenu();
        exitGameButton.clicked += () => ConfirmExit();
        resumeButton.clicked += () => CloseSelf();
        restartButton.clicked += () => RestartLevel();
        
    }


    private void ExitToMainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName:"MainMenu");

    }

    private void ConfirmExit(){
        confirmExitScreen.gameObject.SetActive(true);

    }

    private void CloseSelf(){
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);

    }

    private void RestartLevel() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    // Update is called once per frame
  
}
