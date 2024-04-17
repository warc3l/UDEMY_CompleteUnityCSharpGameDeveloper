using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject deathVFX;
    [SerializeField] private GameObject hitVFX;
    [SerializeField] private int enemyHitLife = 4;
    //[SerializeField] private Transform parent; // - Use the Inspector to inject a parent, otherwise use FindWithTag
    private GameObject parentGameObject; // - Use the Inspector to inject a parent, otherwise use FindWithTag

    [SerializeField] private int scorePerHit = 15; 
    
    private ScoringDashboard scoreDash;
    
    void Start()
    {
        
        // Add the rigid body 
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        // GetComponent<Rigidbody>().useGravity = false;
        rb.useGravity = false;
        
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        
        
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
            vfx.transform.parent = parentGameObject.transform;
            Destroy(gameObject);
        }
        else
        {
            GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
            vfx.transform.parent = parentGameObject.transform;
        }
    }
    
    private void OnParticleTrigger()
    {
        
    }
}
