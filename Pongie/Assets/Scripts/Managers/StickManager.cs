using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickManager : MonoBehaviour
{
    public GameSettings gameSettings;
    public Rigidbody2D rigidPlayer1;
    public Rigidbody2D rigidPlayer2;
    private float max = 4.35f;
    private float min = -4.35f;
    public GameObject player1;
    public GameObject player2;
    private GameObject ball;

    private float Speed { get { return gameSettings.StickSpeed; } }
    private int Difficulty { get { return gameSettings.Difficulty; } }

    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
    }
    void Update()
    {
        if (player2.transform.position.y < max && player2.transform.position.y > min)
        {
            player2.transform.position = new Vector2(10, ball.transform.position.y);
        }
        else
        {
            if (player2.transform.position.y > max)
            {
                player2.transform.Translate(0, -0.1f, 0);
            }
            else
            {
                player2.transform.Translate(0, 0.1f, 0);
            }
        }

        if (player1.transform.position.y < max && player1.transform.position.y > min)
        {
            float movementY = Input.GetAxis("Vertical1");
            Vector2 movement = new Vector2(0, Speed * movementY * Time.deltaTime);
            player1.transform.Translate(movement);
        }
        else
        {
            if (player1.transform.position.y > max)
            {
                player1.transform.Translate(0, -0.1f, 0);
            }
            else
            {
                player1.transform.Translate(0, 0.1f, 0);
            }
        }
        //if (Difficulty == 3)
        //{
        //    player2.transform.position = new Vector2(10, ball.transform.position.y);
        //}
        //else if (Difficulty == 2)
        //{
        //    player2.transform.position = new Vector2(10, ball.transform.position.y * 0.5f);
        //}
        //else if (Difficulty == 1)
        //{
        //    player2.transform.position = new Vector2(10, ball.transform.position.y * 0.35f);
        //}
    }
}
