using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    VisualElement root;
    Button playButton, optionsButton, creditsButton, initialButton, versionButton;

    void OnEnable(){
        root = GetComponent<UIDocument>().rootVisualElement;
        
        playButton = root.Q<Button>("PlayButton");
        optionsButton = root.Q<Button>("OptionsButton");
        creditsButton = root.Q<Button>("CreditsButton");
        initialButton = root.Q<Button>("InitialButton");
        versionButton = root.Q<Button>("VersionButton");

        playButton.clicked += () => Play();
        creditsButton.clicked += () => Credits();
        initialButton.clicked += () => Initial_Build();
        versionButton.clicked += () => Version_Notes(); 
    }

    public void Play() {
        SceneManager.LoadScene(sceneName:"LevelSelection");
    }

    public void Initial_Build() {
        SceneManager.LoadScene(sceneName:"AsteroidsOld");
    }

    public void Credits() {
        SceneManager.LoadScene(sceneName:"Credits");
    }

    public void Version_Notes() {
        SceneManager.LoadScene(sceneName:"VersionNotes");
    }
}
