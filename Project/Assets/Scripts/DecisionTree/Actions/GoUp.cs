using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoUp : Action
{

    public GoUp(GameObject agent): base(agent) { }

    public override int GetAction()
    {
        return Action.UP;
    }
}
