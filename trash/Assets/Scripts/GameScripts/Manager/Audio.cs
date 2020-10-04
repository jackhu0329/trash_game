using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEventCenter.AddEvent("PlayMusic", PlayMusic);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            this.GetComponent<AudioSource>().Play();
        }
    }

    public void PlayMusic()
    {
        this.GetComponent<AudioSource>().Play();
    }
}
