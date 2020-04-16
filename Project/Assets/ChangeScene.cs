using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public string level;
    public string levelGo;

    void  OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.LoadLevel(level, levelGo);
    }

    

}
