using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    public float speed = 50;
    void Start()
    {
    }

    void Update()
    {

        float movementX = Input.GetAxis("Horizontal1");
        float movemenetY = Input.GetAxis("Vertical1");
        Vector2 movement = new Vector2(speed * movementX * Time.deltaTime, speed * movemenetY * Time.deltaTime);
        transform.Translate(movement);

        //4.344
    }
}
