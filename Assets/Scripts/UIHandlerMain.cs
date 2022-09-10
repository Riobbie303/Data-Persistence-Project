using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIHandlerMain : MonoBehaviour
{
    private string playerName;
    private int playerScore;
    public Text highScore;

    public void Awake()
    {
        LoadUser();
    }

    public void LoadUser()
    {
        playerName = ScoreKeeper.Instance.playerName;
        playerScore = ScoreKeeper.Instance.score;
        highScore.text = $"Best Score : {playerName.ToUpper()} : {playerScore}";
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
