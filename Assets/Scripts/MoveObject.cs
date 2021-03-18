using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    public int player;
    public float speed;
    public float stablespeed;
    float inputX;
    float inputY;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        stablespeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal Player " + player);
        inputY = Input.GetAxis("Vertical Player " + player);
        if (inputX != 0 || inputY != 0)
        {
            rb.AddForce(new Vector2(inputX * speed, inputY * -speed));
        }
    }
}
