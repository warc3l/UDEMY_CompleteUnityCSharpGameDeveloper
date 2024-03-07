using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionParticleSystem;
    
    private void OnCollisionEnter(Collision other)
    {
        // OnCollisionEnter will "enable" the physics, so, this will create a "response" when hit
        // String name = this.name;
        Debug.Log(name + " Collided with -> " + other.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Trigger is just a callback function when something has been hit. This is more preferable on our scenario
        // so we need to make sure it is enabled
        Debug.Log($"{name} Triggered with -> {other.gameObject.name}");
        StarCrashSequence();
    }


    void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    void StarCrashSequence()
    {
        explosionParticleSystem.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<CharacterController>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        Invoke("ReloadLevel", 1f);
    }
    
}
