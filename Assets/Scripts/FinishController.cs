using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    public SpriteRenderer backgroundBlink;

    bool p1, p2, blink;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            p1 = true;
            if (p2 && !blink)
            {
                blink = true;
                StartCoroutine("BlinkBackground");
            }
        }
        if (collision.CompareTag("Player2"))
        {
            p2 = true;
            if (p1 && !blink)
            {
                blink = true;
                StartCoroutine("BlinkBackground");
            }
        } else
            if (collision.CompareTag("Coin"))
        {
            GameObject.Find("AudioControler").GetComponent<AudioController>().HandleRequest(1);
            Destroy(collision.transform.parent.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            p1 = false;
        }
        if (collision.CompareTag("Player2"))
        {
            p2 = false;
        }
    }

    IEnumerator BlinkBackground()
    {
        float a = 0.4f;
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSecondsRealtime(0.01f);
            backgroundBlink.color = new Color(0.5f, 0.9f, 0.3f, a);
            a -= 0.4f / 100;
        }
        yield return new WaitForSecondsRealtime(0.5f);

        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSecondsRealtime(0.005f);
            GameObject.Find("loading").transform.position = Vector3.MoveTowards(GameObject.Find("loading").transform.position, 
               new Vector3( Camera.main.transform.position.x, Camera.main.transform.position.y, GameObject.Find("loading").transform.position.z)
                , 1.2f);
        }

        Debug.Log(PlayerPrefs.GetInt("StageNum"));

        if (PlayerPrefs.GetInt("StageNum") == 2)
        {
            PlayerPrefs.SetInt("StageNum", 0);
            PlayerPrefs.Save();
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        } else
        {
            PlayerPrefs.SetInt("StageNum", PlayerPrefs.GetInt("StageNum") + 1);
            PlayerPrefs.Save();
            UnityEngine.SceneManagement.SceneManager.LoadScene(PlayerPrefs.GetInt("Stage"));
        }
    }

}
