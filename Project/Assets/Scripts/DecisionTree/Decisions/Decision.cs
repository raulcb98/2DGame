using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Decision : Node
{
    public Decision(GameObject agent): base(agent) {}

    public abstract Node GetBranch();

    public override Node Decide()
    {
        return GetBranch().Decide();
    }
}
