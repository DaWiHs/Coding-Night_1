using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{

    public bool freezeCamX;
    public bool freezeCamY;
    public float camMaxX;
    public float camMaxY;
    public float camSize;


    // Start is called before the first frame update
    void Start()
    {
        Camera.main.SendMessage("GetData", "" + freezeCamX + "_" + freezeCamY + "_" + camMaxX + "_" + camMaxY + "_" + camSize);
        StartCoroutine("OnBegin");
    }

    IEnumerator OnBegin()
    {
        Instantiate(Camera.main.GetComponentInChildren<KillPlayerOutside>().coin, new GameObject().transform, true).transform.position = GameObject.Find("CoinSpawn").transform.position;
        yield return new WaitForSecondsRealtime(0.5f);
        Instantiate(Camera.main.GetComponentInChildren<KillPlayerOutside>().player1, new GameObject().transform, true).transform.position = GameObject.Find("Spawn").transform.position;
        yield return new WaitForSecondsRealtime(0.5f);
        Instantiate(Camera.main.GetComponentInChildren<KillPlayerOutside>().player2, new GameObject().transform, true).transform.position = GameObject.Find("Spawn").transform.position;
    }
}
