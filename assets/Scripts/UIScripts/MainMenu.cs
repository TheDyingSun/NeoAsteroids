using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    VisualElement root;
    Button storyButton, arcadeButton, exitButton, creditsButton, initialButton, versionButton;

    void OnEnable(){
        root = GetComponent<UIDocument>().rootVisualElement;
        
        storyButton = root.Q<Button>("StoryButton");
        arcadeButton = root.Q<Button>("ArcadeButton");
        exitButton = root.Q<Button>("ExitButton");
        creditsButton = root.Q<Button>("CreditsButton");
        initialButton = root.Q<Button>("InitialButton");
        versionButton = root.Q<Button>("VersionButton");

        storyButton.clicked += () => Story();
        arcadeButton.clicked += () => Story();
        exitButton.clicked += () => Exit();
        creditsButton.clicked += () => Credits();
        initialButton.clicked += () => Initial_Build();
        versionButton.clicked += () => Version_Notes(); 
    }

    public void Story() {
        SceneManager.LoadScene(sceneName:"LevelSelection");
    }

    public void Exit() {
        Application.Quit();
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
