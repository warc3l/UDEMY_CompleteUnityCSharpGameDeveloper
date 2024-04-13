using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float healthPoints = 100.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TakeDamage(float damage)
    {
        healthPoints = healthPoints - damage;
        if (healthPoints <= 0)
        {
            // Destroy(gameObject);
            Debug.Log("Player dead!");
            GetComponent<DeathHandler>().HandleDeath();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
