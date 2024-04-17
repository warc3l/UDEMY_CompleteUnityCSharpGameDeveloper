using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera FPCamera;
    [SerializeField] private float range = 100f;
    [SerializeField] private float damageWeapon = 30f;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private Ammo ammoSlot;
    [SerializeField] private AmmoType ammoType;
    [SerializeField] private TextMeshProUGUI ammoText;
    
    
    void Update()
    {
        DisplayAmmo();
        if (Input.GetButtonDown("Fire1") && ammoSlot.GetAmmo(ammoType) > 0)
        {
            Shoot();
        }
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();
    }

    private void Shoot()
    {
        ammoSlot.ReduceAmmo(ammoType);
        PlayVFXFlash();
        ProcessRayycasting();
    }

    private void PlayVFXFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRayycasting()
    {
        RaycastHit hit;
        if ( Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range) ) {
            Debug.Log("I hit " + hit.transform.name);
            
            // Some visual effects for Hitting

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target != null)
            {
                // And Call a Method in EnemyHealth that decreases the enemy health.
                target.TakeDamage(damageWeapon);                 
            }
        }

    }
    

}
