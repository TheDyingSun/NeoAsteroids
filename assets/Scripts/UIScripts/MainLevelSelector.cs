using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainLevelSelector : MonoBehaviour
{
    VisualElement root;
    Button staticLevelSelector, sideScrollLevelSelector;

    void OnEnable(){
        root = GetComponent<UIDocument>().rootVisualElement;
        
        staticLevelSelector = root.Q<Button>("StaticLevelSelector");
        sideScrollLevelSelector = root.Q<Button>("SideScrollLevelSelector");

        staticLevelSelector.clicked += () => ChangeToStaticLevel();
        sideScrollLevelSelector.clicked += () => ChangeToSideScrollLevel();
    }

    private void ChangeToStaticLevel(){
        SceneStateManager.currentLevel = CurrentLevel.ArcadeStatic;
        SceneManager.LoadScene(sceneName:"Asteroids");

    }

    private void ChangeToSideScrollLevel(){
        SceneStateManager.currentLevel = CurrentLevel.ArcadeSideScroll;
        SceneManager.LoadScene(sceneName:"SideScroller");
    }
}
