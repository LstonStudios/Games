using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button menuButton;

    private void Start()
    {
        pausePanel.SetActive(false);
        resumeButton.onClick.AddListener(Resume);
        restartButton.onClick.AddListener(Restart);
        menuButton.onClick.AddListener(ReturnToMenu);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        bool isPaused = GameManager.Instance.IsPaused;
        pausePanel.SetActive(!isPaused);
        GameManager.Instance.TogglePause();
    }

    private void Resume()
    {
        TogglePause();
    }

    private void Restart()
    {
        GameManager.Instance.RestartLevel();
    }

    private void ReturnToMenu()
    {
        GameManager.Instance.ReturnToMenu();
    }
}
