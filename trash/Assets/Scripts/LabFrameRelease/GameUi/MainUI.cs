using System.Collections;
using System.Collections.Generic;
using GameData;
using LabData;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public GameObject launcher;
    public GameObject editor;
    public Button startButton;
    public Button settingButton;
    public Button settingFinishButton;
    public Button deleteButton;
    public Dropdown hand, angle, dish, choose;
    public InputField scriptName;
    public void Start()
    {
        startButton.onClick.AddListener(StartButtonClick);
        //LabTools.CreateDataFolder<MyGameData>();
        launcher.SetActive(true);
        editor.SetActive(false);
        startButton.onClick.AddListener(StartButtonClick);
        settingButton.onClick.AddListener(SettingButtonClick);
        settingFinishButton.onClick.AddListener(SettingFinishButtonClick);
        //deleteButton.onClick.AddListener(DeleteScripts);
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
        //GameDataManager.FlowData = new GameFlowData("01", data);

        //var Id = gameFlow.UserId;

        //GameDataManager.LabDataManager.LabDataCollectInit(() => Id);
        GameSceneManager.Instance.Change2MainScene();
    }

    private void UpdateList()
    {
        choose.ClearOptions();
        if (LabTools.GetDataName<MyGameData>() != null)
        {
            choose.AddOptions(LabTools.GetDataName<MyGameData>());
        }
        choose.value = 0;
    }

    public void DeleteScripts()
    {
        LabTools.DeleteData<MyGameData>(choose.captionText.text);
        UpdateList();
    }

    public void SettingButtonClick()
    {
        launcher.SetActive(false);
        editor.SetActive(true);

    }

    public void SettingFinishButtonClick()
    {
        MyGameData gameData = new MyGameData();
        //SetData(gameData);

        /*if (scriptName.text != null || scriptName.text != "")
        {
            LabTools.WriteData(gameData, scriptName.text, true);
        }
        else
        {
            LabTools.WriteData(gameData, "default", true);
        }*/
        //LabTools.WriteData(gameData, "test123",true);
        //Debug.Log("dropdown data:" + gameData.hand);
       // Debug.Log("dropdown data:" + gameData.angle);
       // Debug.Log("dropdown data:" + gameData.dishCount);
        launcher.SetActive(true);
        editor.SetActive(false);
       // UpdateList();
    }

}
