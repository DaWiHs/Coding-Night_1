using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerOutside : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;
    public GameObject coin;

    bool resping1, resping2, respingC;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1") && !resping1)
        {
            resping1 = true;
            Destroy(collision.transform.parent.parent.gameObject);
            StartCoroutine("RespawnPlayer", player1);
        } else
            if (collision.CompareTag("Player2") && !resping2)
        {
            resping2 = true;
            Destroy(collision.transform.parent.parent.gameObject);
            StartCoroutine("RespawnPlayer", player2);
        } else 
            if (collision.CompareTag("Coin") && !respingC)
        {
            respingC = true;
            Destroy(collision.gameObject);
            StartCoroutine("RespawnCoin");
        }
    }

    IEnumerator RespawnPlayer(GameObject playerObj)
    {
        yield return new WaitForSecondsRealtime(1f);

        Instantiate(playerObj, new GameObject().transform, true).transform.position = GameObject.Find("Spawn").transform.position;
        resping1 = false;
        resping2 = false;
    }
    IEnumerator RespawnCoin()
    {
        yield return new WaitForSecondsRealtime(1f);

        Instantiate(coin, new GameObject().transform, true).transform.position = GameObject.Find("CoinSpawn").transform.position;
        respingC = false;
    }

}
