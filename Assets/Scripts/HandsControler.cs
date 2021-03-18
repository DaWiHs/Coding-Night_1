using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsControler : MonoBehaviour
{

    AudioController audioCon;
    Rigidbody2D collided;
    HingeJoint2D hinge;
    string holder;
    bool hold;
    MoveObject otherHand;

    public bool isRightHand;
    public Sprite[] hands;

    private void Awake()
    {
        int player = gameObject.GetComponent<MoveObject>().player;

        // Set Grab Key
        if (isRightHand)
        {
            otherHand = GameObject.Find("HandL" + player).GetComponent<MoveObject>();
            holder = "Grab Right P" + player;
        } else {
            holder = "Grab Left P" + player;
            otherHand = GameObject.Find("HandR" + player).GetComponent<MoveObject>();
        }

        audioCon = GameObject.Find("AudioControler").GetComponent<AudioController>();

        //Debug.Log(holder);

    }

    // Update is called once per frame
    void Update()
    {
        // Grab Clip Sound
        if (Input.GetButtonDown(holder))
        {
            audioCon.HandleRequest(0);
        }

        // Grab Mechanic
        if (Input.GetButton(holder)) {
            gameObject.GetComponent<SpriteRenderer>().sprite = hands[1]; // Change Sprite to grab
            if (hold)
            {
                //rb.constraints = RigidbodyConstraints2D.FreezeAll;
                // boost other hand
                otherHand.speed = otherHand.stablespeed * 2.2f;
                if (gameObject.GetComponents<HingeJoint2D>().Length < 2)
                {
                    hinge = gameObject.AddComponent<HingeJoint2D>();
                    hinge.connectedBody = collided.GetComponent<Rigidbody2D>();
                }

            }
        } else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = hands[0];
        }
        if (!Input.GetButton(holder))
        {
            if (gameObject.GetComponents<HingeJoint2D>().Length > 1)
            {
                Destroy(gameObject.GetComponents<HingeJoint2D>()[1]);
            }
            //rb.constraints = RigidbodyConstraints2D.None;
            otherHand.speed = otherHand.stablespeed;
        }
        //Debug.Log(gameObject.GetComponent<HingeJoint2D>().connectedBody);
        //Debug.Log("X: " + Input.GetAxis("Horizontal Player 1") + " Y: " + Input.GetAxis("Vertical Player 1"));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int otherplayer;
        if (gameObject.GetComponent<MoveObject>().player == 1) otherplayer = 2; else otherplayer = 1;
        if (!collision.CompareTag("NoHold") && 
                (
                collision.CompareTag("Player" + otherplayer) ||
                collision.CompareTag("Ground") || 
                collision.CompareTag("Coin")
                )
            )
        {
            hold = true;
            collided = collision.GetComponent<Rigidbody2D>();
            if (collision.CompareTag("Coin"))
            {
                collision.SendMessage("UnfreezeCoin");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        int otherplayer;
        if (gameObject.GetComponent<MoveObject>().player == 1) otherplayer = 2; else otherplayer = 1;

        if (!collision.CompareTag("NoHold") &&
                 (
                 collision.CompareTag("Player" + otherplayer) ||
                 collision.CompareTag("Ground")
                 )
             )
        {
            hold = false;
            collided = null;

        }
    }


}
