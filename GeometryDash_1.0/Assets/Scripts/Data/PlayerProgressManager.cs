using UnityEngine;
using System.Collections.Generic;

public class PlayerProgressManager : MonoBehaviour
{
    public static PlayerProgressManager Instance { get; private set; }

    [SerializeField] private PlayerData playerData;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadPlayerData();
    }

    private void LoadPlayerData()
    {
        string json = PlayerPrefs.GetString("PlayerData", "");
        if (!string.IsNullOrEmpty(json))
        {
            playerData = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            playerData = new PlayerData();
        }
    }

    public void SavePlayerData()
    {
        string json = JsonUtility.ToJson(playerData);
        PlayerPrefs.SetString("PlayerData", json);
        PlayerPrefs.Save();
    }

    public void UnlockLevel(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < playerData.unlockedLevels.Count)
        {
            playerData.unlockedLevels[levelIndex] = true;
            SavePlayerData();
        }
    }

    public void RecordLevelTime(int levelIndex, float time, int attempts)
    {
        if (levelIndex >= 0 && levelIndex < playerData.levelTimes.Count)
        {
            playerData.levelTimes[levelIndex] = time;
            playerData.levelAttempts[levelIndex] = attempts;
            SavePlayerData();
        }
    }

    public bool IsLevelUnlocked(int levelIndex)
    {
        return levelIndex < playerData.unlockedLevels.Count && playerData.unlockedLevels[levelIndex];
    }

    public void SetPlayerIcon(int iconId)
    {
        playerData.selectedIcon = iconId;
        SavePlayerData();
    }

    public void SetPlayerColors(int primaryColor, int secondaryColor)
    {
        playerData.primaryColor = primaryColor;
        playerData.secondaryColor = secondaryColor;
        SavePlayerData();
    }

    public PlayerData GetPlayerData() => playerData;
}

[System.Serializable]
public class PlayerData
{
    public List<bool> unlockedLevels = new List<bool> { true, false, false, false, false, false, false };
    public List<float> levelTimes = new List<float> { 0, 0, 0, 0, 0, 0, 0 };
    public List<int> levelAttempts = new List<int> { 0, 0, 0, 0, 0, 0, 0 };
    public int selectedIcon = 0;
    public int primaryColor = 0;
    public int secondaryColor = 0;
    public int totalDeaths = 0;
    public int levelsCompleted = 0;
}
