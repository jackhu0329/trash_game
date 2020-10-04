using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrame
{
    public class CupEntity : GameEntityBase
    {
        private GameObject targetObj, lockHandle;
        private float timer;

        private Vector3 posStart, posEnd;
        public float moveSpeed = 1; // 實際速度
        public float moveSpeedFixed = 1; // 移動速度
        public float jumpTime = 1f; // 起始點-終點的總時間
        private float jumpTimer;
        private bool jumpInit = true;
        private bool throwBool = false;

        public void Awake()
        {
            // transform.eulerAngles = new Vector3(-90, 0, -90);
            targetObj = GameObject.Find("ThrowTarget");
            lockHandle = GameObject.Find("LockHandle");
        }
        public override void EntityDispose()
        {

        }

        public void Update()
        {
            if (throwBool)
            {
                Throw();
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            Debug.Log("test enter c1");
            timer = 0.0f;
        }

        public void OnTriggerExit(Collider other)
        {

            timer = 0.0f;
        }

        public void OnTriggerStay(Collider other)
        {
            Debug.Log("test enter c1");
            if (!other.CompareTag("CheckPoint"))
            {
                return;
            }
            Debug.Log("test enter correct:" + timer);
            timer += Time.deltaTime;
            if (timer >= 2)
            {
                Debug.Log("test enter correct:" + timer);
                throwBool = true;
            }

        }

        private void Throw()
        {
            posStart = transform.position;
            posEnd = targetObj.transform.position;


            if (jumpInit)
                Jump();

        }

        void Jump()
        {
            jumpTimer += Time.deltaTime * (moveSpeed / moveSpeedFixed);
            float f1 = jumpTimer / jumpTime;
            float f2 = jumpTimer - jumpTimer * f1; // 豎直加速運動
            Vector3 v1 = Vector3.Lerp(posStart, posEnd, f1); // 水平勻速運動
            transform.position = v1 + f2 * Vector3.up;
            if (jumpTimer >= jumpTime)
            {
                jumpTimer = 0;
                jumpInit = false;
                if (!GameDataManager.FlowData.objLock)
                {
                    GameEventCenter.DispatchEvent("SuccessfulMotionSpawn");
                    GameEventCenter.DispatchEvent("CheckCorrect");
                    GameEventCenter.DispatchEvent("GetScore");
                    GameEventCenter.DispatchEvent("ResetHand");
                    //Thread.Sleep(500);
                    //timer = 0f;
                    GameDataManager.FlowData.objLock = true;
                    //GameEventCenter.DispatchEvent("LockOpen");
                    lockHandle.SendMessage("LockOpen");
                }
                Destroy(this.gameObject);
            }
        }
    }
}


