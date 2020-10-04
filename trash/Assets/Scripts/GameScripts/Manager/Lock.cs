using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    private GameObject audio;
    private void Awake()
    {
        audio = GameObject.Find("Audio_get");
        GameEventCenter.AddEvent("LockOpen", LockOpen);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LockOpen()
    {
        GameEventCenter.DispatchEvent("PlayMusic");
        Debug.Log("LockOpenWait1");
        StartCoroutine(LockOpenWait());
    }

    IEnumerator LockOpenWait()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("LockOpenWait2");
        GameDataManager.FlowData.objLock = false;
    }
}
