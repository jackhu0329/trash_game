using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestGameFrame;
using GameFrame;

public class TaskFanctory 
{
    public static List<TaskBase> GetCurrentScopeTasks()
    {
        var temptasks = new List<TaskBase>
        {
            new TrashTask(),
            new CheckTask()
        };
        return temptasks;
    }
}
