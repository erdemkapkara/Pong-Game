using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public float speed = 50;
    public float max = 4.344f;
    public float min = -4.344f;

    void Start()
    {
  
    }

    void Update()
    {
        float movementX = Input.GetAxis("Horizontal2");
        float movementY = Input.GetAxis("Vertical2");

        if (movementY <= max && movementY >= min)
        {
            Vector2 movement = new Vector2(speed * movementX * Time.deltaTime, speed * movementY * Time.deltaTime);
            transform.Translate(movement);
        }
    }
}
