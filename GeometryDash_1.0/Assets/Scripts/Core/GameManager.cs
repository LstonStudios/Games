using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private float gameSpeed = 1f;
    [SerializeField] private bool isPaused = false;
    [SerializeField] private bool isPracticeMode = false;

    private int currentLevelIndex = 0;
    private int attempts = 0;
    private float levelStartTime = 0f;

    public bool IsPaused => isPaused;
    public bool IsPracticeMode => isPracticeMode;
    public float GameSpeed => gameSpeed;
    public int Attempts => attempts;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        levelStartTime = Time.time;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void StartLevel(int levelIndex, bool practiceMode = false)
    {
        currentLevelIndex = levelIndex;
        isPracticeMode = practiceMode;
        attempts = 0;
        Time.timeScale = 1f;
        isPaused = false;
        levelStartTime = Time.time;
    }

    public void RestartLevel()
    {
        attempts++;
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CompleteLevel()
    {
        float levelTime = Time.time - levelStartTime;
        Debug.Log($"Level completed in {levelTime:F2} seconds with {attempts} attempts!");
        
        // Save progress
        PlayerProgressManager.Instance.UnlockLevel(currentLevelIndex + 1);
        PlayerProgressManager.Instance.RecordLevelTime(currentLevelIndex, levelTime, attempts);

        // Load next level or return to menu
        LoadNextLevel();
    }

    public void FailLevel()
    {
        if (!isPracticeMode)
        {
            RestartLevel();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void LoadNextLevel()
    {
        currentLevelIndex++;
        if (currentLevelIndex < LevelManager.TotalLevels)
        {
            SceneManager.LoadScene("Level_" + currentLevelIndex);
        }
        else
        {
            SceneManager.LoadScene("LevelSelect");
        }
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void SetGameSpeed(float speed)
    {
        gameSpeed = Mathf.Clamp(speed, 0.5f, 2f);
    }
}
