using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


namespace GameFrame
{
    public class TrashTask : TaskBase
    {
        private GameObject objCup,objBottle,objPaper;
        private GameObject spawnPoint;

        private int objPointer = 0;
        private int count = 9;
        private int objPosition = 7;

        private List<int> randomSeed = new List<int>();
        private List<GameObject> objList = new List<GameObject>();

        private int[] randomArray;
        private bool leftObj, frontObj, rightObj;

        private float timer = 0f;
        public static bool objLock =false;

        // Start is called before the first frame update
        public override IEnumerator TaskInit()
        {
            Debug.Log("TaskInit start");

            GameEventCenter.AddEvent("SuccessfulMotionSpawn", SuccessfulMotionSpawn);

            objCup = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().Cup.gameObject;
            objBottle = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().Bottle.gameObject;
            objPaper = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().Paper.gameObject;

            //ParseObjValue();
            //GenerateList();
            randomArray = new int[count];
            int seedLength = randomSeed.Count;


            for (int x = 0; x < count; x++)
            {
                //randomArray[x] = randomSeed[Random.Range(0, seedLength)];
                randomArray[x] = Random.Range(1, 4);
                Debug.Log("obj manager:" + randomArray[x]);
            }


            InitGame();


            yield return null;
        }

        //public void 
        public override IEnumerator TaskStart()
        {
            Debug.Log("TaskInit SpawnPan");
            SpawnPan();

            yield return null;
        }


        public override IEnumerator TaskStop()
        {
            yield return null;
        }

        /// <summary>
        /// 
        /// </summary>
        private void SpawnPan()
        {
            //GameObject objClone = GameObject.Instantiate(obj, obj.transform.position, Quaternion.identity);
        }

        private void InitGame()
        {
            //B_Obj.SetActive(false);
            //P_Obj.SetActive(false);
            // C_Obj.SetActive(false);

            SpawnObj();
            //objList[randomArray[objPointer] - 1].SetActive(true);

        }

        private void SpawnObj()
        {
            Debug.Log("TaskInit SpawnObj");
            GameObject objClone;
            switch (Random.Range(1, 4))
            {
                case 1:
                    objClone = GameObject.Instantiate(objCup, objCup.transform.position, Quaternion.identity);
                    break;
                case 2:
                    objClone = GameObject.Instantiate(objBottle, objBottle.transform.position, Quaternion.identity);
                    break;
                case 3:
                    objClone = GameObject.Instantiate(objPaper, objPaper.transform.position, Quaternion.identity);
                    break;
            }
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

            //objList.Add(C_Obj);
            //objList.Add(B_Obj);
            //objList.Add(P_Obj);

        }

        private void ParseObjValue()
        {
            int temp = objPosition;

            leftObj = (temp / 4) == 1 ? true : false;
            frontObj = ((temp % 4) / 2) == 1 ? true : false;
            rightObj = (temp % 2) == 1 ? true : false;

        }

        private void SuccessfulMotionSpawn()
        {
            //objList[randomArray[objPointer] - 1].SetActive(false);
            Debug.Log("TaskInit SuccessfulMotionObj");
            //objPointer++;
            //objLock = true;
            if (!GameDataManager.FlowData.objLock)
            {
                
                Debug.Log("TaskInit SuccessfulMotionObj2");
                SpawnObj();
                GameDataManager.FlowData.objLock = true;
                //Thread.Sleep(500);

                //timer = 0f;
            }
            

            //SpawnObj();
            //objList[randomArray[objPointer] - 1].SetActive(true);
        }

        /*private void  WaitLock()
        {
           
                yield return new WaitForSeconds(1.0f);
                objLock = false;
        }*/


    }
}


