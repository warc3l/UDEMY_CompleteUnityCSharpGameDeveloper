using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetectionHandler : MonoBehaviour
{
    private bool isTransitioning = false;
    [SerializeField] public float delayTime = 1.0f;
    [SerializeField] private AudioClip destroyedRocket;
    [SerializeField] private AudioClip successRocket;

    [SerializeField] private ParticleSystem successParticles;
    [SerializeField] private ParticleSystem destroyParticles;
    
    
    private AudioSource audioSource;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!isTransitioning)
        {
            if (other.gameObject.tag == "Friend")
            {
            }
            else if (other.gameObject.tag == "Fuel")
            {
            
            }
            else if (other.gameObject.tag == "Goal")
            {
                // Next Level!w 
                RocketForward();
            }
            else
            {
                // Destroy
                RocketToExplode();
            }
        }
    }

    void RocketForward()
    {
        isTransitioning = true;
        successParticles.Play();
        GetComponent<Movement>().enabled = false;
        audioSource.Stop();
        audioSource.PlayOneShot(successRocket);
        Invoke( "LoadNextLevel", delayTime);
    }
    
    void RocketToExplode()
    {
        isTransitioning = true;
        destroyParticles.Play();
        GetComponent<Movement>().enabled = false;
        audioSource.Stop();
        audioSource.PlayOneShot(destroyedRocket);
        Invoke( "ReloadLevel", delayTime);
    }
    
    void ReloadLevel()
    {
        // SceneManager.LoadScene("Scenes/EasyScene0");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void LoadNextLevel()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }

        SceneManager.LoadScene(nextScene);
    }
}
