using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoSingletonGeneric<UIManager>
{
    [SerializeField]
    private TextMeshProUGUI scoreTxt, scoreGameOverTxt, highscoreTxt;

    [SerializeField]
    private Image gameoverUIImg;

    private int score = 0, highScore;

    [SerializeField]
    private Joystick floatingJoystick, fixedJoystick;

    [SerializeField]
    private Button retryBtn, startMenuBtn, exitBtn;

    private bool isShooting = false;

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
    }
    public void ScoreIncreament(int scoreIncrement)
    {
        score += scoreIncrement;
        scoreTxt.text = "Score : " + score;
        scoreGameOverTxt.text = "Score : " + score;
    }
    public void GameoverUI(bool o)
    {
        gameoverUIImg.gameObject.SetActive(o);
        highScore = Mathf.Max(highScore, score);

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
