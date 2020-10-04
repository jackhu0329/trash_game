using GameData;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int count = 9;
    private int[] randomArray ;
    private int gamePointer = 0;
    void Start()
    {
        //GameEventCenter.AddEvent("SuccessfulMotion", SuccessfulMotion);
        GameEventCenter.AddEvent("SuccessfulMotion", SuccessfulMotion);
        randomArray = new int[count];
        for(int x = 0; x < count; x++)
        {
            randomArray[x] = UnityEngine.Random.Range(0, 9);
            Debug.Log("generate random value:" + randomArray[x]);
        }


        InitGame();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SuccessfulMotion();
            GameDataManager.FlowData.objLock = false;
        }

        if(gamePointer == count)
        {
            Debug.Log("finish");
        }
    }

    private void InitGame()
    {
        for (int x = 0; x < 9; x++)
        {
            transform.GetChild(x).gameObject.SetActive(false);
        }

        transform.GetChild(randomArray[gamePointer]).gameObject.SetActive(true);
    }

    private void SuccessfulMotion()
    {
        Debug.Log("check SuccessfulMotion");
        transform.GetChild(randomArray[gamePointer]).gameObject.SetActive(false);
        gamePointer++;
        transform.GetChild(randomArray[gamePointer]).gameObject.SetActive(true);
        //StartCoroutine(unLock());
        //GameDataManager.FlowData.objLock = false;
    }

    IEnumerator  unLock()
    {
        yield return new WaitForSeconds(1.0f);
        GameDataManager.FlowData.objLock = false;
    }
}
