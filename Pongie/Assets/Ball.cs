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
    Rigidbody2D rigidBall;
    public float speed = 10;
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

    void Start()
    {
        rigidBall = GetComponent<Rigidbody2D>();

        float x = Random.Range(20, -20);
        float y = Random.Range(-20, -20);

        Vector2 Movement = new Vector2(x, y);
        rigidBall.AddForce(Movement);
        rigidBall.velocity = Movement;//new Vector2(speed * x, speed * y);

        Button btn = ButtonClick.GetComponent<Button>();
        btn.onClick.AddListener(ResetScore);
        
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
