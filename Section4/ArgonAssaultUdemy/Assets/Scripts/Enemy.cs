using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject deathVFX;
    [SerializeField] private GameObject hitVFX;
    [SerializeField] private int enemyHitLife = 4;
    [SerializeField] private Transform parent;

    [SerializeField] private int scorePerHit = 15; 
    
    private ScoringDashboard scoreDash;

    void Start()
    {
        // We can use this SAFELY as we are SURE that we will have ONLY ONE score board
        // It is a resource consuming, and heavier and heavier... but it is fine for now with only one
        scoreDash = FindObjectOfType <ScoringDashboard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        scoreDash.IncreaseScore(scorePerHit);
        enemyHitLife--;
        if (enemyHitLife < 1)
        {
            GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
            vfx.transform.parent = parent;
            Destroy(gameObject);
        }
        else
        {
            GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
            vfx.transform.parent = parent;
        }
    }

    private void OnParticleTrigger()
    {
        
    }
}
