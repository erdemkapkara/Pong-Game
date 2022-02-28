using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]

public class Ball : MonoBehaviour
{
    public TextMeshProUGUI txt1;
    public TextMeshProUGUI txt2;
    public TextMeshProUGUI txt3;
    public int score1 = 0, score2 = 0;
    public Rigidbody2D rigidBall;
    public GameSettings gameSettings;
    public string win = "You Won The Game!!!";
    public string lost = "You Lost The Game!!!";
    public float Velocity { get { return gameSettings.BallSpeed; } }
    public int NumberOfLevel { get { return gameSettings.MaxScore; } }

    public void ActivePassive(bool x)
    {
        if (x == true)
        {
            GetComponent<SpriteRenderer>().enabled = x;
            GameObject.Find("Player1").SetActive(x);
            GameObject.Find("Player2").SetActive(x);
            GameObject.Find("Text1").SetActive(x);
            GameObject.Find("Text2").SetActive(x);
        }
        else {
            GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("Player1").SetActive(false);
            GameObject.Find("Player2").SetActive(false);
            GameObject.Find("Text1").SetActive(false);
            GameObject.Find("Text2").SetActive(false);
        }
    }
    public void FinishGame()
    {
        ResetScore();
        ResetPosition();
        if (score1 > score2)
        {
            txt3.text = win;
        }
        else
        {
            txt3.text = lost;
        }
        ActivePassive(false);
    }
    public void ResetScore()
    {
        score1 = 0;
        score2 = 0;
        transform.position = new Vector2(0, 0);
        txt1.text = score1.ToString();
        txt2.text = score2.ToString();
        ActivePassive(true);
    }
    public void ResetPosition()
    {
        transform.position = new Vector2(0, 0);
    }
    public void UpdateScore(int player)
    {
        if (player == 1)
        {
            score2++;
        }
        else if (player == 2)
        {
            score1++;
        }
    }

    public Button ButtonClick;
    public Button ButtonClickPlay;

    void Start()
    {
        Button PlayButton = ButtonClickPlay.GetComponent<Button>();
        PlayButton.onClick.AddListener(Play);

        rigidBall = GetComponent<Rigidbody2D>();

        float x = Random.Range(5, -5);
        float y = Random.Range(5, -5);

        Vector2 Movement = new Vector2(x, y);
        //rigidBall.AddForce(Movement, ForceMode2D.Impulse);
        rigidBall.velocity = new Vector2(Velocity * x, Velocity * y);

        Button btn = ButtonClick.GetComponent<Button>();
        btn.onClick.AddListener(ResetScore);
    }

    public GameObject Players;
    public GameObject Canvases;
    public GameObject CanvasStartt;
    public void Play()
    {
        ActivePassive(true);
        Players.SetActive(true);
        Canvases.SetActive(true);
        CanvasStartt.SetActive(false);
        GetComponent<SpriteRenderer>().enabled = true;
        ResetPosition();
        ResetScore();
    }
    void Update()
    {
        if (score1 < NumberOfLevel && score2 < NumberOfLevel)
        {
            txt1.text = score1.ToString();
            txt2.text = score2.ToString();
        }
        else
        {
            FinishGame();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LeftWall"))
        {
            ResetPosition();
            UpdateScore(1);
        }
        if (collision.gameObject.CompareTag("RightWall"))
        {
            ResetPosition();
            UpdateScore(2);
        }
    }

}
