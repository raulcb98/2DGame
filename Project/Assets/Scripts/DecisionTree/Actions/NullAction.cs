using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullAction : Action
{

    public NullAction(GameObject agent) : base(agent) { }

    public override int GetAction()
    {
        return Action.NULL;
    }
}
