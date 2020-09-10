using NAudio.Gui.TrackView;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Music : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("LoadSong");
        LoadSong();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSong()
    {
        //StartCoroutine(LoadSongCoroutine());
    }

    IEnumerator LoadSongCoroutine()
    {
        string url = string.Format(Application.persistentDataPath + "/test.mp3");
        Debug.Log("LoadSong url:"+ url);
        WWW www = new WWW(url);
        yield return www;

        audioSource.clip = NAudioPlayer.FromMp3Data(www.bytes);
        audioSource.Play();


    }

   /* IEnumerator LoadSongCoroutine()
    {
        //fileExplorer.fileName --> for file path [Used : SmartExplorer plugin from github]
        UnityWebRequest webRequest = UnityWebRequestMultimedia.GetAudioClip(Application.persistentDataPath + "/test.mp3", AudioType.OGGVORBIS);
        yield return webRequest.SendWebRequest();

        if (webRequest.isNetworkError)
        {
            Debug.Log(webRequest.error);
        }

        audioSource.clip = DownloadHandlerAudioClip.GetContent(webRequest);
        audioSource.Play();
    }*/
}
