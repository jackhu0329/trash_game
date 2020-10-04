using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjControl : MonoBehaviour
{
    private bool inCheckPoint = false;
    private Vector3 originPosition,originRoatation;
    private Material green ,yellow;
    private int timerStart, timerEnd;
    private bool timer=false;
    // Start is called before the first frame update

    private void Awake()
    {
        green = Resources.Load("Material/green", typeof(Material)) as Material;
        yellow = Resources.Load("Material/yellow", typeof(Material)) as Material;

        GameEventCenter.AddEvent("ResetObj", ResetObj);
    }
    void Start()
    {
        originPosition = transform.position;
        originRoatation = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("test enter Throw 1");
            if (inCheckPoint)
            {
                Debug.Log("test enter Throw 2");
                GameEventCenter.DispatchEvent("Throw");
            }
        }

        if (timer)
        {
            timerEnd = Mathf.FloorToInt(Time.time) - timerStart;
            if (timerEnd == 1)
            {
                //Debug.Log("test enter successful timer!!!!!!");
                timerStart = 0;
                timer = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            //Debug.Log("test enter correct");
            inCheckPoint = true;
            other.GetComponent<MeshRenderer>().material = green;
            timerStart = Mathf.FloorToInt(Time.time);
            timer = true;
            //

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            Debug.Log("test enter exit");
            inCheckPoint = false;
            other.GetComponent<MeshRenderer>().material = yellow;

            timerStart = 0;
            timer = false;
            //

        }
    }

    private void ResetObj()
    {
        Debug.Log("ResetObj");
        transform.position = originPosition;
        transform.eulerAngles = originRoatation;
        this.gameObject.SetActive(false);
    }
}
