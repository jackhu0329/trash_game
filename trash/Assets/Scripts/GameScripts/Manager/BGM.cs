using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public AudioClip clip, get;
    // Start is called before the first frame update
    void Start()
    {
        GameEventCenter.AddEvent("BGMFinish", BGMFinish);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BGMFinish()
    {
        this.GetComponent<AudioSource>().clip = clip;
        this.GetComponent<AudioSource>().Play();
    }
}
