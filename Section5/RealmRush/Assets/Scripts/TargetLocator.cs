using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] private Transform weapon;
    [SerializeField] private ParticleSystem projectParticles;
    [SerializeField] private float range = 15f; 
    
    /*[SerializeField]*/ private Transform target;

    /*
    void Start()
    {
        // target = FindObjectOfType<EnemyMover>().transform;
        target = FindObjectOfType<Enemy>().transform;
    }
    */

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestEnemy = null;
        float maxDistance = Mathf.Infinity;
        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(enemy.transform.position, transform.position);
            if (targetDistance < maxDistance)
            {
                closestEnemy = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closestEnemy;
    }
    
    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    public void AimWeapon()
    {
        float targetDistancia = Vector3.Distance(transform.position, target.position);
        Attack(targetDistancia < range);
        weapon.LookAt(target);   
    }

    public void Attack(bool isActive)
    {
        var emissionModule = projectParticles.emission;
        emissionModule.enabled = isActive;
    }
    
}
