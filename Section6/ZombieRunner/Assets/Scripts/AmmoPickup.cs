using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class AmmoPickup : MonoBehaviour
    {
        [SerializeField] private int ammoAmount = 5;
        [SerializeField] private AmmoType ammoType;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                FindObjectOfType<Ammo>().IncreaseAmmo(ammoType, ammoAmount);
                Destroy(gameObject);
            }
        }
    }
}