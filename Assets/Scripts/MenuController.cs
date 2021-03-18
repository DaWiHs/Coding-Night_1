using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    void Play1()
    {
        PlayerPrefs.SetInt("StageNum", 0);
        PlayerPrefs.SetInt("Stage", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }
    void Play2()
    {
        PlayerPrefs.SetInt("StageNum", 0);
        PlayerPrefs.SetInt("Stage", 2);
        PlayerPrefs.Save();
        SceneManager.LoadScene(2);
    }

    void Exit()
    {
        Application.Quit();
    }
}
