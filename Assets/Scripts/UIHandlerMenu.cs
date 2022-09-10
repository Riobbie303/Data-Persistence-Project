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
    public string playerName;
    public TMP_InputField inputField;
    public TMP_Text highscoreText;
    public Button playButton;

    public void Start()
    {
        playButton.interactable = false;
        ScoreKeeper.Instance.LoadGameRank();
        highscoreText.text = $"Highscore - {ScoreKeeper.Instance.bestPlayer.ToUpper()}: {ScoreKeeper.Instance.bestScore}";
    }

    public void SaveText()
    {
        playButton.interactable = true;
        playerName = inputField.text;
        ScoreKeeper.Instance.currentPlayer = playerName;
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
