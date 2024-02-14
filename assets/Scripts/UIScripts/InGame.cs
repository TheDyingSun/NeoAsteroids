using UnityEngine;
using UnityEngine.UIElements;

public class InGame : MonoBehaviour
{
    [SerializeField]
    VisualElement root;
    Label scoreElement;
    VisualElement life_1;
    VisualElement life_2;
    VisualElement life_3;
    Label winConditionText;
    Label winProgress;

    void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement; 
        scoreElement = root.Q<Label>("score");
        scoreElement.text = "00000000";

        life_1 = root.Q<VisualElement>("life_1");
        life_2 = root.Q<VisualElement>("life_2");
        life_3 = root.Q<VisualElement>("life_3");

        winConditionText = root.Q<Label>("win_condition");
        winProgress = root.Q<Label>("progress");
    }

    public void updateWinCondition(GameManager.WinCondition condition) {
        switch (condition) {
            case GameManager.WinCondition.Number:
                winConditionText.text = "asteroids left:";
                break;
            case GameManager.WinCondition.Time:
                winConditionText.text = "time left:";
                break;
            case GameManager.WinCondition.Score:
                winConditionText.text = "score left:";
                break;
        }
    }

    public void updateScore(int score) {
        scoreElement.text = score.ToString("D8");
    }

    public void updateLives(int lives) {
        switch (lives) {
            case 0:
                life_1.style.display = DisplayStyle.None;
                life_2.style.display = DisplayStyle.None;
                life_3.style.display = DisplayStyle.None;
                break;
            case 1:
                life_1.style.display = DisplayStyle.Flex;
                life_2.style.display = DisplayStyle.None;
                life_3.style.display = DisplayStyle.None;
                break;
            case 2:
                life_1.style.display = DisplayStyle.Flex;
                life_2.style.display = DisplayStyle.Flex;
                life_3.style.display = DisplayStyle.None;
                break;
            case 3:
                life_1.style.display = DisplayStyle.Flex;
                life_2.style.display = DisplayStyle.Flex;
                life_3.style.display = DisplayStyle.Flex;
                break;  
        }
    }

    public void updateWinProgress(string newText) {
        winProgress.text = newText;
    }
}
