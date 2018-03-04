using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using Helix.Components.Operator;

public class Enemy : MonoBehaviour
{
    private Operator _operator;

    public Animator anim;
    private NavMeshAgent navAgent;
    private bool attackAnimCommited;

    public Enemy()
    {
    }

    public void Awake()
    {
        this._operator = new Operator(new OperatorStats(100, 0, 0, 0, 50f));

        navAgent = GetComponent<NavMeshAgent>() == null ? gameObject.AddComponent<NavMeshAgent>() : null;

        navAgent.angularSpeed = 10000;
        navAgent.acceleration = 10000;


        HealthBar healthBar = gameObject.AddComponent<HealthBar>();
        healthBar.Link(GetOperator());

    }
    // Use this for initialization
    void Start()
    {
    }
	
    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = GameObject.Find("Player").transform.position;

        if (Vector3.Distance(playerPosition, transform.position) < _operator.GetStats().GetAttackRange())
        {
            Attack();
        }
        else
        {
            Chase(playerPosition);
        }
    }

    void Attack()
    {
        if (navAgent.enabled)
        {
            navAgent.enabled = false;
        }
    }

    void Chase(Vector3 target)
    {        

        if (!navAgent.enabled)
        {            
            navAgent.enabled = true;
        }

        if (navAgent.isActiveAndEnabled)
        {
            navAgent.SetDestination(target);
        }
    }

    public Operator GetOperator()
    {
        return _operator;
    }
}
