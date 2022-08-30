using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TMPro.TMP_InputField inputName;
    public TMPro.TMP_Text textHighScore;

    [SerializeField]
    public static string currentPlayer;

    public static void ResetHighScores()
    {
        PlayerPrefs.DeleteKey("HighScoreName");
        PlayerPrefs.DeleteKey("HighScore");
        if (Application.isPlaying)
        {
            SceneManager.LoadScene(0);
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    private void Start()
    {
        SetHighScoreText();
    }

    private void SetHighScoreText()
    {
        string player = PlayerPrefs.GetString("HighScoreName", "no one yet");
        int score = PlayerPrefs.GetInt("HighScore", 0);
        textHighScore.text = $"Highscore: {score} by {player} ";
    }

    public void OnClickStart()
    {
        currentPlayer = inputName.text;
        PlayerPrefs.SetString("Name", inputName.text);
        SceneManager.LoadScene(1);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    internal static void CheckHighScore(int currentScore)
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (currentScore > highScore)
        {
            PlayerPrefs.SetString("HighScoreName", currentPlayer);
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
    }

    internal static string GetHighScoretext()
    {
        string player = PlayerPrefs.GetString("HighScoreName", "no one yet");
        int score = PlayerPrefs.GetInt("HighScore", 0);
        return $"Highscore: {score} by {player} ";
    }
}
