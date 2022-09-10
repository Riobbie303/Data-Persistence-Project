using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIHandlerMenu : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject menuScore;
    public TMP_Text menuScoreText;
    public Button playButton;
    private int playerScore;

    public void Awake()
    {
        SetObjects(false);
    }

    public void SaveText()
    {
        SetObjects(true);
        LoadScores();
    }

    private void SetObjects(bool switchIt)
    {
        menuScore.SetActive(switchIt);
        playButton.interactable = switchIt;
    }

    private void LoadScores()
    {
        ScoreKeeper.Instance.playerName = inputField.text;
        ScoreKeeper.Instance.score = playerScore;
        menuScoreText.text = $"High Score : {playerScore}";
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
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
