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
    [SerializeField] private float speed = 5f;
    
    
    private float distanceToFriend = Mathf.Infinity;
    private NavMeshAgent navMeshAgent;

    private bool isProvoked = false;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
   
    private void EngageTarget()
    {
        FaceTarget();
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
        
        // Need to move from idle state to the move state.
        GetComponent<Animator>().SetTrigger("move"); // Exactly as it is spelled
    }
    
    void AttackTarget()
    {
        Debug.Log(name + " attacking " + target.name);
        
        // Attacking, without Event
        /*
        EnemyAttack enemyAttack = GetComponent<EnemyAttack>();
        if (enemyAttack != null)
        {
            enemyAttack.AttackHitEvent();
        }
        */
        
        // Need to move from move to attack
        GetComponent<Animator>().SetBool("attack", true);
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

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion quaternion = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, quaternion, Time.deltaTime * speed); // Check Slerp method.
    }
    

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, saveDistance);
    }
}
