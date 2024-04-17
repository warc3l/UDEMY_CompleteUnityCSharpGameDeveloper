using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // [SerializeField] private Transform target;
    [SerializeField] private float damage = 40.0f; // Damage
    private PlayerHealth target;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
        
        
    }
    
    public void OnDamageTaken()
    {
        // What to do when damage is taken?
        Debug.Log(name + " I also know that we took damage");
    }

    
    public void AttackHitEvent()
    {
        if (target != null)
        {
            Debug.Log("bang bong");
            target.GetComponent<DisplayDamage>().ShowDamageImpact();
            target.TakeDamage(damage);
        }
    }
    
    
    
}
