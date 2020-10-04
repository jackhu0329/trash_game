using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataSync;
using LabData;

namespace GameData
{
    public class GameFlowData : LabDataBase
    {
        /// <summary>
        /// 语言
        /// </summary>
        public Language Language { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId { get; set; } = "Test01";
        public MyGameData GameData = new MyGameData();

        public bool objLock=false;

        /// <summary>
        /// FlowData 构造函数
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="languageType"></param>
        /// <param name="remindType"></param>
        /// <param name="gameData"></param>
        public GameFlowData(string UserID, MyGameData data)
        {
            GameData = data;
            UserId = UserID;
        }

        public GameFlowData()
        {
        }
    }
}