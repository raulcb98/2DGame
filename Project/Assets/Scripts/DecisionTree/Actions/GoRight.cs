using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoRight : Action
{
    public GoRight(GameObject agent) : base(agent) { }

    public override int GetAction()
    {
        return Action.RIGHT;
    }
}
