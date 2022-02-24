using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerMovement : MonoBehaviour
{
    public Rigidbody2D rigidPlayer1;
    Vector3 speed = new Vector3(0, 10);
    //public float speed = 10;

    private GameObject ball;
    private float ballPosition;
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    void FixedUpdate()
    {
        ballPosition = ball.transform.position.y;

        if (transform.position.y != ballPosition && ball.transform.position.x>0)
        {
            Vector2 movement = new Vector2(0, ballPosition);
            transform.position = transform.position + (speed * Time.deltaTime);
            //transform.Translate(movement*Time.deltaTime*speed);
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

        /*
            float movementX = Input.GetAxis("Horizontal1");
            float movemenetY = Input.GetAxis("Vertical1");
            Vector2 movement = new Vector2(speed * movementX * Time.deltaTime, speed * movemenetY * Time.deltaTime);
            transform.Translate(movement);
        */
    }
}
