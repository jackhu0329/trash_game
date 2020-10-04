using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrame
{
    public class CupEntity : GameEntityBase
    {
        private GameObject targetObj;
        private float timer;

        private Vector3 posStart, posEnd;
        public float moveSpeed = 2; // 實際速度
        public float moveSpeedFixed = 2; // 移動速度
        public float jumpTime = 2f; // 起始點-終點的總時間
        private float jumpTimer;
        private bool jumpInit = true;

        public void Awake()
        {
            // transform.eulerAngles = new Vector3(-90, 0, -90);
            targetObj = GameObject.Find("ThrowTarget");
        }
        public override void EntityDispose()
        {

        }

        public void OnTriggerEnter(Collider other)
        {

            timer = 0.0f;
        }

        public void OnTriggerExit(Collider other)
        {

            timer = 0.0f;
        }

        public void OnTriggerStay(Collider other)
        {
            if (!other.CompareTag("CheckPoint"))
            {
                return;
            }

            timer += Time.deltaTime;
            if (timer >= 2)
            {
                Throw();
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
                //transform.GetChild(1).gameObject.SetActive(false);
                //targetObj.transform.GetChild(1).gameObject.SetActive(true);
                Destroy(this.gameObject);

            }
        }
    }
}

