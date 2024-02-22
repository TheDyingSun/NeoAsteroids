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
        //SceneStateManager.ChangeCurrentStage("Static");
        SceneManager.LoadScene(sceneName:"Asteroids");

    }

    private void ChangeToSideScrollLevel(){
        //SceneStateManager.ChangeCurrentStage("SideScroller");
        SceneManager.LoadScene(sceneName:"SideScroller");

    }

    private void ChangeToCutScene(){
        //SceneStateManager.ChangeCurrentStage("CutScene");
        SceneManager.LoadScene(sceneName:"CutScene");
    }

}
