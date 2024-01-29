using System.Collections;
using System.Collections.Generic;
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

        //Setup eventlisteners
        staticLevelSelector.clicked += () => ChangeToStaticLevel();
        sideScrollLevelSelector.clicked += () => ChangeToSideScrollLevel();
        cutSceneLevelSelector.clicked += () => ChangeToCutScene();
        
    }

    private void ChangeToStaticLevel(){
        SceneManager.LoadScene(sceneName:"Asteroids");

    }

    private void ChangeToSideScrollLevel(){
        SceneManager.LoadScene(sceneName:"SideScrollLevel");

    }

    private void ChangeToCutScene(){
        SceneManager.LoadScene(sceneName:"CutScene");

    }


}
