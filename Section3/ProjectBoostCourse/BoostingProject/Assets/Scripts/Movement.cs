using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    
    
    [SerializeField] private float thrust = 150.0f;
    [SerializeField] private float rotationThrust = 35.0f;
    private Rigidbody rb;
    private AudioSource audioSource;
    [SerializeField] private AudioClip mainAudioClip;
    [SerializeField] private ParticleSystem mainCohetParticles;
    [SerializeField] private ParticleSystem leftCohetParticles;
    [SerializeField] private ParticleSystem rightCohetParticles;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        DoingThrust();
        DoingRotation();  
    }

    void DoingThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Thrusting....");
            // Rider complains "operation inefficient" if Vector3.up * thrust * deltaTime
            rb.AddRelativeForce( new Vector3(0, thrust * Time.deltaTime, 0));
            if (!audioSource.isPlaying)
            {
                // audioSource.Play();
                audioSource.PlayOneShot(mainAudioClip);
            }

            if (!mainCohetParticles.isPlaying)
            {
                mainCohetParticles.Play();
            }
        }
        else
        {
            audioSource.Stop();
            mainCohetParticles.Stop();
        }  
    }


    void DoingRotation()
    {
        rb.freezeRotation = true; // freezing rotation so we manual rotate
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThrust * Time.deltaTime);
            if (!rightCohetParticles.isPlaying)
            {
                rightCohetParticles.Play();
            }
        }
        
        else if (Input.GetKey(KeyCode.D))
        {
            rightCohetParticles.Stop();

            transform.Rotate(-Vector3.forward * rotationThrust * Time.deltaTime);
            if (!leftCohetParticles.isPlaying)
            {
                leftCohetParticles.Play();
            }
        }
        else
        {
            rightCohetParticles.Stop();
            leftCohetParticles.Stop();
        }
        rb.freezeRotation = false; // unfreezing rotation so we manual rotate
    }
}
