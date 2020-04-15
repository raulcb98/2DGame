using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogDecisionTree : Tree
{
    private void Start()
    {
        GameObject agent = gameObject;

        // Level 0
        root = new IsPlayerNear(agent, 7f);

        // Level 1
        AreEnoughEnemiesAround areEnoughEnemiesAround = new AreEnoughEnemiesAround(agent, 2, 10);
        NullAction nullAction = new NullAction(agent);
        root.yesNode = areEnoughEnemiesAround;
        root.noNode = nullAction;

        // Level 2
        GoUp goUp = new GoUp(agent);
        EnoughHealth enoughHealth = new EnoughHealth(agent, 30);
        areEnoughEnemiesAround.yesNode = goUp;
        areEnoughEnemiesAround.noNode = enoughHealth;

        // Level 3
        Attack attack = new Attack(agent);
        RunAway runAway = new RunAway(agent);
        enoughHealth.yesNode = attack;
        enoughHealth.noNode = runAway;
    }
}
