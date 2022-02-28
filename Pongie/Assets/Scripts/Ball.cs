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
    public int score1 = 0, score2 = 0;
    public Rigidbody2D rigidBall;
    public float velocity = 5;

    public void ResetScore()
    {
        score1 = 0;
        score2 = 0;
        transform.position = new Vector2(0, 0);
        txt1.text = score1.ToString();
        txt2.text = score2.ToString();
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

    /*public string theSpeed  ;
    public string theLevel;
    public GameObject inputFieldSpeed;
    public GameObject inputFieldLevel;
    public Text neBu;*/
    void Start()
    {
        /*//inputFieldLevel = GameObject.Find("TextL");
        //inputFieldSpeed = GameObject.Find("TextS");
        inputFieldSpeed = GameObject.Find("CanvasStart");

        neBu = inputFieldSpeed.GetComponentInChildren<Text>();
        neBu = inputFieldSpeed.GetComponentInChildren<Text>();
        Debug.Log(neBu);
        //theLevel=inputFieldLevel.GetComponent<Text>().text;
        //theSpeed=inputFieldSpeed.GetComponent<Text>().text;
        Debug.Log(theSpeed);
        Debug.Log(theLevel);*/
         
        Button PlayButton = ButtonClickPlay.GetComponent<Button>();
        PlayButton.onClick.AddListener(Play);

        rigidBall = GetComponent<Rigidbody2D>();

        float x = Random.Range(5, -5);
        float y = Random.Range(5, -5);

        Vector2 Movement = new Vector2(x, y);
        //rigidBall.AddForce(Movement, ForceMode2D.Impulse);
        rigidBall.velocity = new Vector2(velocity * x, velocity * y);

        Button btn = ButtonClick.GetComponent<Button>();
        btn.onClick.AddListener(ResetScore);
    }

    public GameObject Players;
    public GameObject Canvases;
    public GameObject CanvasStartt;
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
        txt1.text = score1.ToString();
        txt2.text = score2.ToString();
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
