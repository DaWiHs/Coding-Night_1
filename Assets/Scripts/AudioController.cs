using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioClip[] clips;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleRequest(int id)
    {
        GetComponent<AudioSource>().clip = clips[id];
        GetComponent<AudioSource>().Play();
    }

}
