using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    protected Node root;

    public int Decide()
    {
        return root.Decide().GetAction();
    }
}
