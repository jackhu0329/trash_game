using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataSync;

namespace LabData
{
    public class MyGameData : LabDataBase
    {
       
        public int count { get; set; }
        public int checkArea { get; set; } //low mid high -> 3bit

        public int trashArea { get; set; } // left mid right -> 3bit

        public MyGameData()
        {
            count = 5;
            checkArea = 7;
            trashArea = 7;
        }
        public MyGameData(int countValue, int checkAreaValue, int trashAreaValue)
        {
            count = countValue;
            checkArea = checkAreaValue;
            trashArea = trashAreaValue;
        }

    }
}
