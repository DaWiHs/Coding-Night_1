using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stages : MonoBehaviour
{

    public GameObject[] stages;

    // Start is called before the first frame update
    void Start()
    {
        stages[PlayerPrefs.GetInt("StageNum")].SetActive(true);
    }
}
