using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] private Transform weapon;

    /*[SerializeField]*/ private Transform target;

    void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
    }
    void Update()
    {
        AimWeapon();
    }

    public void AimWeapon()
    {
        weapon.LookAt(target);   
    }
    
}
