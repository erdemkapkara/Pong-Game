using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerMovement : MonoBehaviour
{
    public Rigidbody2D rigidPlayer1;
    Vector3 speed = new Vector3(0, 25);
    //public float speed = 10;

    private GameObject ball;
    private float ballPosition;
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    void FixedUpdate()
    {
        //distance = Vector2.Distance(transform.position, ball.transform.position);
        //transform.position = new Vector3(transform.position.y, ball.transform.position.y, speed*Time.deltaTime);
        ballPosition = ball.transform.position.y;

        if (transform.position.y != ballPosition && ball.transform.position.x>0)
        {
            Vector2 movement = new Vector2(0,01f*ballPosition);
            transform.Translate(0, 0.3f*ballPosition, 0);
        }
        
        /* float duration = ball.transform.position.y;

         if (duration < 0)
         { 
             if (ball == null)
             {
                 return;
             }
             else
             {
                 duration = ball.transform.position.y;
             }
         }

         Vector2 calculatedPosition = ball.transform.position;

         float stickMinSpeedToReach = Vector2.Distance(this.transform.position, calculatedPosition) / duration;

         stickMinSpeedToReach = Mathf.Max(stickMinSpeedToReach, 2f);

         this.transform.position = Vector2.MoveTowards(this.transform.position, calculatedPosition, Time.deltaTime * stickMinSpeedToReach);

         */
    }
}
