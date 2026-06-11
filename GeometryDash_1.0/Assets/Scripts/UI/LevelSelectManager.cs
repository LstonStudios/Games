using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    [SerializeField] private Transform levelButtonContainer;
    [SerializeField] private GameObject levelButtonPrefab;
    [SerializeField] private Text levelInfoText;

    private void Start()
    {
        PopulateLevelSelect();
    }

    private void PopulateLevelSelect()
    {
        for (int i = 0; i < LevelManager.TotalLevels; i++)
        {
            LevelData level = LevelManager.Instance.GetLevel(i);
            bool isUnlocked = PlayerProgressManager.Instance.IsLevelUnlocked(i);

            GameObject buttonObj = Instantiate(levelButtonPrefab, levelButtonContainer);
            Button button = buttonObj.GetComponent<Button>();
            Text buttonText = buttonObj.GetComponentInChildren<Text>();

            buttonText.text = $"{i + 1}. {level.name}\n{level.difficulty}";
            button.interactable = isUnlocked;

            int levelIndex = i; // Local copy for closure
            button.onClick.AddListener(() => LoadLevel(levelIndex));
        }
    }

    private void LoadLevel(int levelIndex)
    {
        GameManager.Instance.StartLevel(levelIndex, false);
        SceneManager.LoadScene("Level_" + levelIndex);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
