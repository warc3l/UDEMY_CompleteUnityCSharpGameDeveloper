using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    private Vector3 startingPos;

    [SerializeField] private Vector3 moveVect;

    // Range to create cool sliders in the Inspector
    // [SerializeField] [Range(0,1)]
    private float moveFact;
    [SerializeField] private float period = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        // Debug.Log(startingPos);
    }

    // Update is called once per frame
    void Update()
    {
        if (period > 0.01f)
        {
            float cycles = Time.time / period; // We will have 1 cycle once we have [2] period
            float sinWave = Mathf.Sin(cycles * Mathf.PI * 2);
           
            moveFact = (sinWave + 1f) / 2f;
            //Vector3 offset = sinWave * moveVect * moveFact;
            Vector3 offset = moveVect * moveFact;
            transform.position = startingPos + offset;
        }
    }
}
