using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoSingletonGeneric<UIManager>
{

    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private TextMeshProUGUI scoreTxt, scoreGameOverTxt, highscoreTxt;

    [SerializeField]
    private Image gameoverUIImg;

    private int score = 0, highScore;

    [SerializeField]
    private Joystick floatingJoystick, fixedJoystick;

    [SerializeField]
    private Button retryBtn, startMenuBtn, exitBtn;

    protected override void Awake()
    {
        base.Awake();
        retryBtn.onClick.AddListener(RetryMenu);
        startMenuBtn.onClick.AddListener(LoadStartMenu);
        exitBtn.onClick.AddListener(Quit);
    }

    public void Start()
    {
        InputManager.Instance.SetJoystick(floatingJoystick);
        GameoverUI(false);
        highScore = PlayerPrefs.GetInt("Highscore");
    }
    public void ScoreIncreament(int scoreIncrement)
    {
        score += scoreIncrement;
        scoreTxt.text = "Score : " + score;
        scoreGameOverTxt.text = "Score : " + score;
        highScore = Mathf.Max(highScore, score);
        highscoreTxt.text = "High Score : " + highScore;
        PlayerPrefs.SetInt("Highscore", highScore);
    }
    public void GameoverUI(bool o)
    {
        gameoverUIImg.gameObject.SetActive(o);
    }
    private void RetryMenu()
    {
        SceneManager.LoadScene(1);
    }
    private void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void Quit()
    {
        Application.Quit();
    }
}
