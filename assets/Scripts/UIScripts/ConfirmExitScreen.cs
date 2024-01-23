using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ConfirmExitScreen : MonoBehaviour{
    // Start is called before the first frame update

    VisualElement root;
    Button confirmExit, declineExit;
    void OnEnable(){

        root = GetComponent<UIDocument>().rootVisualElement;
        
        confirmExit = root.Q<Button>("ConfirmExit");
        declineExit = root.Q<Button>("DeclineExit");

        confirmExit.clicked += () => Application.Quit();
        declineExit.clicked += () => CloseSelf();
       
    }

    

    private void CloseSelf(){
        this.gameObject.SetActive(false);

    }
}
