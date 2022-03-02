using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI txt1;
    public TextMeshProUGUI txt2;
    public TextMeshProUGUI txt3;
    private int score1 = 0, score2 = 0;

    public GameSettings gameSettings;

    private string win = "You Won The Game!!!";
    private string lost = "You Lost The Game!!!";
    private string empty = " ";

    public Button ButtonClick;
    public BallManager Ballmanager;
    public GameObject Ball;// Field
    private int MaxScore { get { return gameSettings.MaxScore; } }
    public void FinishGame()
    {
        if (score1 > score2)
        {
            txt3.text = win;
        }
        else
        {
            txt3.text = lost;
        }
        Ball.SetActive(false);
        Ballmanager.FinishGame();
    }
    public void ResetScore()
    {
        score1 = 0;
        score2 = 0;
        txt1.text = score1.ToString();
        txt2.text = score2.ToString();
        txt3.text = empty;
        Ball.SetActive(true);
        Ballmanager.ResetScore();  
    }
    public void UpdateScore(int player)
    {
        if (player == 1)
        {
            score2++;
            txt2.text = score2.ToString();
        }
        else if (player == 2)
        {
            score1++;
            txt1.text = score1.ToString();
        }
    }
    void Start()
    {
        Ball = GameObject.Find("Ball");

        Button btn = ButtonClick.GetComponent<Button>();
        btn.onClick.AddListener(ResetScore);
    }
    public void Play()
    {
        Ball.SetActive(true);
        ResetScore();
    }
    void Update()
    {
        if (score1 >= MaxScore || score2 >= MaxScore)
        {
            FinishGame();
        }
    }
}
