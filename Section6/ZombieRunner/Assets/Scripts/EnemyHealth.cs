using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health = 100f;

    private bool justDieOnce = false;
    
    public float Health
    {
        get { return health; }
    }

    public void TakeDamage(float damage)
    {
        health = health - damage;
        // There are couple of ways to get OnDamageEvent from EnemyAI (we can get the GetComponent from EnemyAI)
            // What to if there are multiple places where to take the damage? We do not really care who does the action
            // which component.
            
        // We can use a BroadcastMessage, with the name of the method that we would like to call.
        BroadcastMessage("OnDamageTaken");         
        if (health <= 0 && !justDieOnce)
        {
            // Destroy(gameObject);
            justDieOnce = true;
            Die();
        }
    }

    private void Die()
    {
        GetComponent<Animator>().SetTrigger("die");
    }
    
}
