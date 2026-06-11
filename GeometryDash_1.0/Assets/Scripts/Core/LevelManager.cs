using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    public const int TotalLevels = 7;

    [SerializeField] private List<LevelData> levels = new List<LevelData>();
    private int currentCheckpoint = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        InitializeLevels();
    }

    private void InitializeLevels()
    {
        levels.Clear();
        levels.Add(new LevelData("Stereo Madness", "ForeverBound", 0, Difficulty.Easy));
        levels.Add(new LevelData("Back on Track", "DJVI", 1, Difficulty.Easy));
        levels.Add(new LevelData("Polargeist", "Step", 2, Difficulty.Normal));
        levels.Add(new LevelData("Dry Out", "DJVI", 3, Difficulty.Normal));
        levels.Add(new LevelData("Base After Base", "DJVI", 4, Difficulty.Hard));
        levels.Add(new LevelData("Can't Let Go", "DJVI", 5, Difficulty.Harder));
        levels.Add(new LevelData("Jumper", "Waterflame", 6, Difficulty.Insane));
    }

    public LevelData GetLevel(int index)
    {
        if (index >= 0 && index < levels.Count)
        {
            return levels[index];
        }
        return null;
    }

    public void SetCheckpoint(int checkpointIndex)
    {
        currentCheckpoint = checkpointIndex;
    }

    public int GetCurrentCheckpoint() => currentCheckpoint;

    public void ResetCheckpoint()
    {
        currentCheckpoint = 0;
    }
}

public class LevelData
{
    public string name;
    public string artist;
    public int index;
    public Difficulty difficulty;

    public LevelData(string name, string artist, int index, Difficulty difficulty)
    {
        this.name = name;
        this.artist = artist;
        this.index = index;
        this.difficulty = difficulty;
    }
}

public enum Difficulty
{
    Easy,
    Normal,
    Hard,
    Harder,
    Insane
}
