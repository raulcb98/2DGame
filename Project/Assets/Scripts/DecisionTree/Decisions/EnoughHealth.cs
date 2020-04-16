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

    public override bool Check()
    {
        Enemy enemy = agent.GetComponent<Enemy>();
        return enemy.health >= healthThreshold;
    }

    public override int GetAction()
    {
        throw new System.NotImplementedException();
    }
}
