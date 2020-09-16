using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowManager : MonoBehaviour
{
    public GameObject cup, bottle, paper;
    private GameObject throwObject;
    private Vector3 posStart, posEnd;
    public float moveSpeed = 2; // 實際速度
    public float moveSpeedFixed = 2; // 移動速度
    public float jumpTime = 2f; // 起始點-終點的總時間
    private float jumpTimer;
    private bool jumpInit = false;
    // Start is called before the first frame update
    void Start()
    {
        GameEventCenter.AddEvent("Throw",Throw);
        posEnd = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (cup.transform.GetChild(2).gameObject.activeSelf)
        {
            throwObject = cup.transform.GetChild(2).gameObject;
        }
        else if (bottle.transform.GetChild(2).gameObject.activeSelf)
        {
            throwObject = bottle.transform.GetChild(2).gameObject;
        }
        else if (paper.transform.GetChild(2).gameObject.activeSelf)
        {
            throwObject = paper.transform.GetChild(2).gameObject;
        }
        //Debug.Log("throwObject name:"+throwObject.name);

        if (Input.GetKeyDown(KeyCode.A))
        {

        }

        if (jumpInit)
            Jump();
    }

    

    void Jump()
    {
        jumpTimer += Time.deltaTime * (moveSpeed / moveSpeedFixed);
        float f1 = jumpTimer / jumpTime;
        float f2 = jumpTimer - jumpTimer * f1; // 豎直加速運動
        Vector3 v1 = Vector3.Lerp(posStart, posEnd, f1); // 水平勻速運動
        throwObject.transform.position = v1 + f2 * Vector3.up;
        if (jumpTimer >= jumpTime)
        {
            Debug.Log("throwObject end");
            jumpTimer = 0;
            jumpInit = false;
            //throwObject.SetActive(false);
            GameEventCenter.DispatchEvent("ResetObj");
            GameEventCenter.DispatchEvent("SuccessfulMotion");
            // pan.transform.GetChild(1).gameObject.SetActive(false);
            // throwObject.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    private void Throw()
    {
        posStart = throwObject.transform.position;

        Debug.Log("throwObject start");
        jumpInit = true;
    }
}
