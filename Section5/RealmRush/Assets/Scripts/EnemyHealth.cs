using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHitPoints = 5;

    private int currentHitPoints;
    
    // Start is called before the first frame update
    //void Start()
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
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
            gameObject.SetActive(false);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
