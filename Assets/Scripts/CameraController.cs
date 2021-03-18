using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    bool freezeX, freezeY;
    float maxX, maxY;
    GameObject player1head, player2head;
    Vector3 targetPosition;

    void GetData(string data)
    {
        string[] datas = data.Split('_');
        freezeX = bool.Parse(datas[0]);
        freezeY = bool.Parse(datas[1]);
        maxX = float.Parse(datas[2]);
        maxY = float.Parse(datas[3]);
        Camera.main.orthographicSize = float.Parse(datas[4]);
    }

    private void Awake()
    {
        Debug.Log("Awake");
        player1head = GameObject.Find("Head P1");
        player2head = GameObject.Find("Head P2");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameObject.Find("Head P1") == null && GameObject.Find("Head P2") == null)
        {
            targetPosition = new Vector3(0, 0, -10);
        } else {
            player1head = GameObject.Find("Head P1");
            player2head = GameObject.Find("Head P2");
        
            float x = 0;
            float y = 0;
            if (!freezeX)
            {
                x = (player1head.transform.position.x + player2head.transform.position.x) / 2;
            }
            if (!freezeY)
            {
                y = (player1head.transform.position.y + player2head.transform.position.y) / 2;
            }
            if (x < 0) x = 0;
            if (x > maxX) x = maxX;
            if (y < 0) y = 0;
            if (y > maxY) y = maxY;
        

            targetPosition = new Vector3( x , y , -10);
        }
        Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, targetPosition, 0.3f);

        
    }
}
