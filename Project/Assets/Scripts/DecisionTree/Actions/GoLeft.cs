using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoLeft : Action
{
    
    public GoLeft(GameObject agent) : base(agent) { }

    public override int GetAction()
    {
        return Action.LEFT;
    }
}
