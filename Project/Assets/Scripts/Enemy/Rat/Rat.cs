using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;
    private Rat leader;
    private Player player;
    private Action leaderAction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    public void move(int action)
    {
        if(rb.velocity.y == 0)
        {
            if (action == Action.LEFT) rb.velocity = new Vector2(-speed, 0);
            if (action == Action.RIGHT) rb.velocity = new Vector2(speed, 0);
        }
    }

    public void SetLeader(Rat leader)
    {
        if(this.leader == null)
        {
            this.leader = leader;
        }
    }


    public Rat GetLeader()
    {
        return this.leader;
    }


    public Action GetLeaderAction()
    {
        return this.leaderAction;
    }


    public void SelectLeader(float distance)
    {
        List<Rat> ratList = GetRatsAtDistance(distance);
        Rat leader = GetNearestRatToPlayer();

        for(int i = 0; i < ratList.Count; i++)
        {
            ratList[i].SetLeader(leader);
        }
    }


    private List<Rat> GetRatsAtDistance(float distance)
    {
        List<Rat> ratList = new List<Rat>();
        Rat[] ratArray = FindObjectsOfType<Rat>();

        for(int i = 0; i < ratArray.Length; i++)
        {
            if(Vector2.Distance(transform.position, ratArray[i].transform.position) <= distance) {
                ratList.Add(ratArray[i]);
            }
        }

        return ratList;
    }

    private Rat GetNearestRatToPlayer()
    {
        Rat[] ratArray = FindObjectsOfType<Rat>();
        Rat bestRat = null;
        float bestDistance = Mathf.Infinity;

        Rat currentRat;
        float currentDistance;

        Vector2 playerPos = player.transform.position;

        for (int i = 0; i < ratArray.Length; i++)
        {
            currentRat = ratArray[i];
            currentDistance = Vector2.Distance(currentRat.transform.position, playerPos);

            if(currentDistance < bestDistance)
            {
                bestRat = currentRat;
                bestDistance = currentDistance;
            }
        }

        return bestRat;
    }

    
    public void CalculateLeaderAction(float distance)
    {
        if(this.leader == this)
        {
            List<Rat> ratList = GetRatsAtDistance(distance);
            float attackProbability = 0.6f;

            for (int i = 0; i < ratList.Capacity; i++)
            {
                attackProbability += 0.05f;
            }

            float valor = Random.Range(0.0f, 1.0f);
            if (attackProbability > valor)
            {
                this.leaderAction = new Attack(gameObject);
            }
            else
            {
                this.leaderAction = new RunAway(gameObject);
            }
        }

    }
}
