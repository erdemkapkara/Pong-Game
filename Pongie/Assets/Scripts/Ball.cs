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
    public string empty = " ";

    public Button ButtonClick;
    public Button ButtonClickPlay;

    public Vector2 direction;

    public GameObject Players;
    public GameObject Canvases;
    public GameObject CanvasStartt;
    public float Velocity { get { return gameSettings.BallSpeed; } }
    public int NumberOfLevel { get { return gameSettings.MaxScore; } }

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
        ResetPosition();
        GetComponent<SpriteRenderer>().enabled = false;
    }
    public void ResetScore()
    {
        score1 = 0;
        score2 = 0;
        transform.position = new Vector2(0, 0);
        txt1.text = score1.ToString();
        txt2.text = score2.ToString();
        txt3.text = empty;
        GetComponent<SpriteRenderer>().enabled = true;
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

    void Start()
    {
        Button PlayButton = ButtonClickPlay.GetComponent<Button>();
        PlayButton.onClick.AddListener(Play);

        rigidBall = GetComponent<Rigidbody2D>();
        direction = Vector2.one.normalized;

        Button btn = ButtonClick.GetComponent<Button>();
        btn.onClick.AddListener(ResetScore);
    }
    private void FixedUpdate()
    {
        rigidBall.velocity = direction * Velocity;
    }

    public void Play()
    {
        Players.SetActive(true);
        Canvases.SetActive(true);
        CanvasStartt.SetActive(false);
        GetComponent<SpriteRenderer>().enabled = true;
        ResetPosition();
        ResetScore();
    }
    void Update()
    {
        if (score1 >= NumberOfLevel || score2 >= NumberOfLevel)
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
            txt2.text = score2.ToString();
        }
        if (collision.gameObject.CompareTag("RightWall"))
        {
            ResetPosition();
            UpdateScore(2);
            txt1.text = score1.ToString();
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            direction.y = -direction.y;
        }
        if (collision.gameObject.CompareTag("Player1"))
        {
            direction.x = -direction.x;
        }
        if (collision.gameObject.CompareTag("Player2"))
        {
            direction.x = -direction.x;
        }
    }
}
