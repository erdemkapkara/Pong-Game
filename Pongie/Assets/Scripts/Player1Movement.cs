using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    public Rigidbody2D rigidPlayer1;
    public float speed = 50;

    void FixedUpdate()
    {
            float movemenetY = Input.GetAxis("Vertical1");
            Vector2 movement = new Vector2(0, speed * movemenetY * Time.deltaTime);
            transform.Translate(movement);
    }
}
