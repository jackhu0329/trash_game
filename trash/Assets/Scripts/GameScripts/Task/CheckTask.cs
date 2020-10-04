using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

namespace GameFrame
{
    public class CheckTask : TaskBase
    {
        private GameObject checkArea;

        private int count = 5;
        private int[] randomArray;
        private int gamePointer = 0;
        // Start is called before the first frame update
        public override IEnumerator TaskInit()
        {
            Debug.Log("TaskInit checktask");
            checkArea= GameObject.Find("CheckArea");
            GameEventCenter.AddEvent("CheckCorrect", CheckCorrect);
            randomArray = new int[count*2+2];
            for (int x = 0; x < count*2+2; x++)
            {
                randomArray[x] = UnityEngine.Random.Range(0, 9);
                Debug.Log("generate random value:" + randomArray[x]);
            }


            InitGame();

            yield return null;
        }

        //public void 
        public override IEnumerator TaskStart()
        {


            yield return null;
        }


        public override IEnumerator TaskStop()
        {
            yield return null;
        }

        private void InitGame()
        {
            for (int x = 0; x < 9; x++)
            {
                checkArea.transform.GetChild(x).gameObject.SetActive(false);
            }

            checkArea.transform.GetChild(randomArray[gamePointer]).gameObject.SetActive(true);
        }

        private void CheckCorrect()
        {
           // Debug.Log("check SuccessfulMotion");
            checkArea.transform.GetChild(randomArray[gamePointer]).gameObject.SetActive(false);
            gamePointer++;
            Debug.Log("generate gamePointer" + gamePointer);
            checkArea.transform.GetChild(randomArray[gamePointer]).gameObject.SetActive(true);
            
            //StartCoroutine(unLock());
            //GameDataManager.FlowData.objLock = false;
        }

        IEnumerator unLock()
        {
            yield return new WaitForSeconds(1.0f);
            GameDataManager.FlowData.objLock = false;
        }
    }
}

