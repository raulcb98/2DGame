using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnoughHealth : Decision
{
    private float healthThreshold;

    public EnoughHealth(GameObject agent, float healthThreshold): base(agent)
    {
        this.healthThreshold = healthThreshold;
    }

    public override int GetAction()
    {
        throw new System.NotImplementedException();
    }

    public override Node GetBranch()
    {
        Enemy enemy = agent.GetComponent<Enemy>();
        if(enemy.health >= healthThreshold)
        {
            return yesNode;
        }
        else
        {
            return noNode;
        }
    }
}
