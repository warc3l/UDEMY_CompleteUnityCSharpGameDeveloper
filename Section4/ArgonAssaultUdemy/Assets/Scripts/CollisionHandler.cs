using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        // String name = this.name;
        Debug.Log(name + " Collided with -> " + other.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{name} Triggered with -> {other.gameObject.name}");
    }
}
