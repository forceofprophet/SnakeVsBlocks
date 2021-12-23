using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    public GameObject WonMenuUI;
    public GameObject LossMenuUI;
    public GameObject RecordMenuUI;
    public GameObject snake;
    SnakeMovement snakeMovement;
    public Text score;
    public Text loseScore;
    public Text highScore;
    public Text newRecord;
    private void Start()
    {
        snakeMovement = snake.GetComponent<SnakeMovement>();
        WonMenuUI.SetActive(false);
        LossMenuUI.SetActive(false);
        RecordMenuUI.SetActive(false);
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        newRecord.text = PlayerPrefs.GetInt("NewRecord", 0).ToString();
    }
    private void Update()
    {
        score.text = snakeMovement.score.ToString();
        if (snakeMovement.score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", snakeMovement.score);
            highScore.text = snakeMovement.score.ToString();
        }
        if (PlayerPrefs.GetInt("HighScore", 0) > PlayerPrefs.GetInt("NewRecord", 0))
        {
            RecordMenuUI.SetActive(true);
            PlayerPrefs.SetInt("NewRecord", snakeMovement.score);
            newRecord.text = snakeMovement.score.ToString();
        }
    }
    public void Won()
    {
        WonMenuUI.SetActive(true);
        LossMenuUI.SetActive(false);
    }
    public void Loss()
    {
        LossMenuUI.SetActive(true);
        WonMenuUI.SetActive(false);
        loseScore.text = snakeMovement.score.ToString();
    }
}
