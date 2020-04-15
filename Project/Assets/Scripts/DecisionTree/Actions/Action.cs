using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : Node 
{
    public static int NULL = 0;
    public static int LEFT = 1;
    public static int RIGHT = 2;
    public static int UP = 3;
    

    public Action(GameObject agent) : base(agent) { }

    public override Node Decide()
    {
        return this;
    }
}
