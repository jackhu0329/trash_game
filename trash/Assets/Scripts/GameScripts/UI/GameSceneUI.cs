using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {

        GUIStyle gameUI = new GUIStyle();
        gameUI.normal.textColor = new Color(255, 255, 255);
        gameUI.fontSize = 30;

        GUI.Label(new Rect(Screen.width / 10 * 1, (Screen.height / 6 * 5), 200, 100),
        "已完成1次"  
        , gameUI);
    }
}
