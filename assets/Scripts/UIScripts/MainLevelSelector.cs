using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainLevelSelector : MonoBehaviour
{
    VisualElement root;
    Button staticLevelSelector, sideScrollLevelSelector, cutSceneLevelSelector;

    void OnEnable(){
        root = GetComponent<UIDocument>().rootVisualElement;
        
        staticLevelSelector = root.Q<Button>("StaticLevelSelector");
        sideScrollLevelSelector = root.Q<Button>("SideScrollLevelSelector");
        cutSceneLevelSelector = root.Q<Button>("CutSceneLevelSelector");

        staticLevelSelector.clicked += () => ChangeToStaticLevel();
        sideScrollLevelSelector.clicked += () => ChangeToSideScrollLevel();
        cutSceneLevelSelector.clicked += () => ChangeToCutScene();
    }

    private void ChangeToStaticLevel(){
        SceneStateManager.currentLevel = CurrentLevel.FirstLevel;
        SceneManager.LoadScene(sceneName: "Asteroids");
    }

    private void ChangeToSideScrollLevel(){
        SceneStateManager.currentLevel = CurrentLevel.SecondLevel;
        SceneManager.LoadScene(sceneName: "SideScroller");
    }

    private void ChangeToCutScene(){
        SceneStateManager.currentLevel = CurrentLevel.FirstCutScene;
        SceneManager.LoadScene(sceneName: "CutScene");
    }
}
