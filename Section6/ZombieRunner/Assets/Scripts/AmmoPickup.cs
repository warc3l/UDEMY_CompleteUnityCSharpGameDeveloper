using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class AmmoPickup : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                Destroy(gameObject);
            }
        }
    }
}