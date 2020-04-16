using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node 
{
    protected GameObject agent;

    public Node yesNode;
    public Node noNode;

    public Node(GameObject agent)
    {
        this.agent = agent;
    }

    public abstract Node Decide();

    public abstract int GetAction();

}
