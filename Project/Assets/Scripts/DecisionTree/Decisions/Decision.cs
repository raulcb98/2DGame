using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Decision : Node
{
    public Decision(GameObject agent): base(agent) {}

    public abstract bool Check();

    public Node GetBranch()
    {
        if (Check())
        {
            return yesNode;
        }
        else
        {
            return noNode;
        }
    }
    

    public override Node Decide()
    {
        return GetBranch().Decide();
    }
}
