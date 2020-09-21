using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneUI : MonoBehaviour
{
    private int score = 0;
    private int time,start,end;
    public Text timeUI,scoreUI;

    // Start is called before the first frame update
    void Awake()
    {
        GameEventCenter.AddEvent("successfulInUI", successfulInUI);
    }

    private void Start()
    {
        start = Mathf.FloorToInt(Time.time);
    }
    // Update is called once per frame
    void Update()
    {
        if(score == GameDataManager.FlowData.GameData.count)
        {
            time = Mathf.FloorToInt(Time.time) - start;
            transform.GetComponent<Canvas>().transform.GetChild(0).gameObject.SetActive(true);
            scoreUI.text = "完成數量:" + score;
            timeUI.text = "花費時間:" + time;

        }
    }

    void OnGUI()
    {

        GUIStyle gameUI = new GUIStyle();
        gameUI.normal.textColor = new Color(255, 255, 255);
        gameUI.fontSize = 30;

        GUI.Label(new Rect(Screen.width / 10 * 1, (Screen.height / 6 * 5), 200, 100),
        "已完成"+score+"次"  
        , gameUI);
    }

    private void successfulInUI()
    {
        score++;
    }
}
