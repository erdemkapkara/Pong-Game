using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    public GameSettings gameSettings;
    public Rigidbody2D rigidPlayer1;
    public float Speed { get { return gameSettings.StickSpeed; } }

    void FixedUpdate()
    {
            float movementY = Input.GetAxis("Vertical1");
            Vector2 movement = new Vector2(0, Speed * movementY * Time.deltaTime);
            transform.Translate(movement);
    }
}
