using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerMovement : MonoBehaviour
{
    public GameSettings gameSettings;
    public Rigidbody2D rigidPlayer1;

    private GameObject ball;

    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    void FixedUpdate()
    {
            transform.position = new Vector2(10, ball.transform.position.y);
    }
}
