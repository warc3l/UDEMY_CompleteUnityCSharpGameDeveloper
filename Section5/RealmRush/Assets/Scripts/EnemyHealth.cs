using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))] // It pulls-in the Enemy once the EnemyHealth is attached.
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHitPoints = 5;
    [Tooltip("Adds amount to maxHitPoints when enemy dies.")]
    [SerializeField] private int difficultRamp = 1;
    private int currentHitPoints;
    private Enemy enemy;
    
    // Start is called before the first frame update
    //void Start()
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    public void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHitPoints--;
        if (currentHitPoints <= 0)
        {
            //Destroy(gameObject);
            maxHitPoints += difficultRamp;
            gameObject.SetActive(false);
            enemy.RewardGold();
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
