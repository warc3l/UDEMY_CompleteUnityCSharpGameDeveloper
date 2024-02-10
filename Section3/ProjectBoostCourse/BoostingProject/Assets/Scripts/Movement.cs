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
        }
        else
        {
            audioSource.Stop();
        }  
    }


    void DoingRotation()
    {
        rb.freezeRotation = true; // freezing rotation so we manual rotate
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThrust * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationThrust * Time.deltaTime);
        }
        rb.freezeRotation = false; // unfreezing rotation so we manual rotate
    }
}
