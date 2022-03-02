using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

[RequireComponent(typeof(Rigidbody2D))]

public class BallManager : MonoBehaviour
{
    public Rigidbody2D rigidBall;
    public GameSettings gameSettings;

    private Vector2 direction; // Field
    public GameManager gameManager;

    private float _Velocity;
    public float Velocity 
    { 
        get 
        {
            //if (gameSettings == null) 
            //{
            //    throw new NullReferenceException("Game Settings is Unassigned");
            //}

            //if(_Velocity == 0)
            //{
            //    _Velocity = gameSettings.BallSpeed;
            //}

            return _Velocity; 
        }
        set
        {
            _Velocity = value;
        }
    } // Property
    //public int NumberOfLevel { get { return gameSettings.MaxScore; } }

    private void OnValidate()
    {
        if(rigidBall == null)
        {
            rigidBall = GetComponent<Rigidbody2D>();
        }
    }

    public void FinishGame()
    {
        ResetPosition();
    }
    public void ResetScore()
    {
        transform.position = new Vector2(0, 0);
    }
    public void ResetPosition()
    {
        transform.position = new Vector2(0, 0);
    }
    void Start()
    {
        _Velocity = gameSettings.BallSpeed;

        rigidBall = GetComponent<Rigidbody2D>();
        direction = Vector2.one.normalized;
    }
    private void FixedUpdate()
    {
        rigidBall.velocity = direction * Velocity;
    }
    public void Play()
    {
        ResetPosition();
        ResetScore();
        gameManager.ResetScore();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LeftWall"))
        {
            ResetPosition();
            gameManager.UpdateScore(1);
        }
        if (collision.gameObject.CompareTag("RightWall"))
        {
            ResetPosition();
            gameManager.UpdateScore(2);
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
