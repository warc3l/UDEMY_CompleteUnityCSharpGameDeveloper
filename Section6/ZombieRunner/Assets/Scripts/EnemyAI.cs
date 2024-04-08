using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] private float saveDistance = 5f;

    private float distanceToFriend = Mathf.Infinity;
    private NavMeshAgent navMeshAgent;

    private bool isProvoked = false;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
   
    private void EngageTarget()
    {
        if (distanceToFriend >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceToFriend <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }
    
    void AttackTarget()
    {
        Debug.Log(name + " attacking " + target.name);
    }
    
    void Update()
    {
        distanceToFriend = Vector3.Distance(target.position, transform.position);
        
        if (isProvoked)
        {
            EngageTarget();
        } 
        else if (distanceToFriend <= saveDistance)
        {
            isProvoked = true;
            navMeshAgent.SetDestination(target.position);
        }
    }
    

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, saveDistance);
    }
}
