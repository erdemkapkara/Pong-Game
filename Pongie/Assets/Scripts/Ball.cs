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
    
    //public InputField Speedinput;
    public GameObject Speedinput;
    public string input;
    public void ReadInput(string s)
    {
        input = s;
        Debug.Log(input);
    }
    void Start()
    {
        /*string input1 = Speedinput.GetComponent<InputField>().ToString();
        float velocityy = float.Parse(input1);
        velocity = velocityy;
        Debug.Log(velocity);*/

        Button PlayButton = ButtonClickPlay.GetComponent<Button>();
        PlayButton.onClick.AddListener(Play);

        rigidBall = GetComponent<Rigidbody2D>();
        
        float x = Random.Range(20, -20);
        float y = Random.Range(-20, -20);

        Vector2 Movement = new Vector2(x, y);
        //rigidBall.AddForce(Movement, ForceMode2D.Impulse);
        rigidBall.velocity = new Vector2(velocity * x, velocity * y);

        Button btn = ButtonClick.GetComponent<Button>();
        btn.onClick.AddListener(ResetScore);
        ReadInput(input);
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
