using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static int currentLevelIndex;
    bool isFinished;
    public bool isDead;
    private void Awake()
    {
        isFinished = false;
    }
    private void Start()
    {
    }
    private void Update()
    {
        if (isFinished)
        {
        
        }

    }
    public enum State
    {
        Playing,
        Won,
        Loss,
    }
    public State currentState { get; private set; }

    public void OnPlayerDied()
    {
        isDead = true;
        isFinished = true;
        if (currentState != State.Playing) return;
        currentState = State.Loss;
    }
    public void OnPlayerReachedFinish()
    {
        isFinished = true;
        if (currentState != State.Playing) return;
        currentState = State.Won;
        LevelIndex++;
    }
    public int LevelIndex
    {
        get => PlayerPrefs.GetInt("LevelIndex", 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }
    private const string LevelIndexKey = "LevelIndex";
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
