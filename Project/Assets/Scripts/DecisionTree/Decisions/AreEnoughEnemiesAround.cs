using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreEnoughEnemiesAround : Decision
{
    private int enemiesThreshold;
    private float distance;

    public AreEnoughEnemiesAround(GameObject agent, int enemiesThreshold, float distance) : base(agent)
    {
        this.enemiesThreshold = enemiesThreshold;
        this.distance = distance;
    }

    public override int GetAction()
    {
        throw new System.NotImplementedException();
    }

    public override bool Check()
    {
        Enemy enemy = agent.GetComponent<Enemy>();
        int enemyCounter = enemy.CountEnemiesAtDistance(distance);
        return enemyCounter >= enemiesThreshold;
    }
}
