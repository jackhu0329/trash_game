using System.Collections;
using System.Collections.Generic;
using GameData;
using LabData;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public void Start()
    {
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameSceneManager.Instance.Change2MainScene();
        }
        
    }

    public void StartButtonClick()
    {
        //MyGameData data = LabTools.GetData<MyGameData>(choose.captionText.text);
        MyGameData data = LabTools.GetData<MyGameData>("123");
        //GameFlowData gameFlow = new GameFlowData();
        //Debug.Log(data.angle);
        //GameDataManager.FlowData = gameFlow;
        GameDataManager.FlowData = new GameFlowData("01", data);

        //var Id = gameFlow.UserId;

        //GameDataManager.LabDataManager.LabDataCollectInit(() => Id);
        GameSceneManager.Instance.Change2MainScene();
    }

}
