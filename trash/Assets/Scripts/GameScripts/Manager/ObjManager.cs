using NLog.LayoutRenderers;
using RootMotion.FinalIK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjManager : MonoBehaviour
{
    public GameObject B_Obj, P_Obj, C_Obj;

    private int objPointer = 0;
    private int count = 9;
    private int objPosition=7;
    
    private List<int> randomSeed = new List<int>();
    private List<GameObject> objList = new List<GameObject>();

    private int[] randomArray;
    private bool leftObj, frontObj, rightObj;
    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("obj manager start");

        GameEventCenter.AddEvent("SuccessfulMotionObj", SuccessfulMotionObj);
        ParseObjValue();
        GenerateList();
        randomArray = new int[count];
        int seedLength = randomSeed.Count;


        for (int x = 0; x < count; x++)
        {
            randomArray[x] = randomSeed[Random.Range(0, seedLength)];
            Debug.Log("obj manager:" + randomArray[x]);
        }


        InitGame();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("obj manager SuccessfulMotion");
            SuccessfulMotionObj();
        }
    }

    private void InitGame()
    {
        B_Obj.SetActive(false);
        P_Obj.SetActive(false);
        C_Obj.SetActive(false);

        objList[randomArray[objPointer]-1].SetActive(true);

    }

    private void GenerateList()
    {
        if (leftObj)
        {
            Debug.Log("obj manager add 1");
            randomSeed.Add(1);
        }

        if (frontObj)
        {
            Debug.Log("obj manager add 2");
            randomSeed.Add(2);
        }

        if (rightObj)
        {
            Debug.Log("obj manager add 3");
            randomSeed.Add(3);
        }

        objList.Add(C_Obj);
        objList.Add(B_Obj);
        objList.Add(P_Obj);

    }

    private void ParseObjValue()
    {
        int temp = objPosition;

        leftObj = (temp / 4) == 1 ? true : false;
        frontObj = ((temp % 4) / 2) == 1 ? true : false;
        rightObj = (temp % 2) == 1 ? true : false;

    }

    private void SuccessfulMotionObj()
    {
        objList[randomArray[objPointer]-1].SetActive(false);
        objPointer++;
        objList[randomArray[objPointer]-1].SetActive(true);
    }
}
