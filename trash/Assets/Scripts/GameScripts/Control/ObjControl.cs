using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjControl : MonoBehaviour
{
    private bool inCheckPoint = false;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            Debug.Log("test enter correct");
            inCheckPoint = true;
            //

        }
    }
}
