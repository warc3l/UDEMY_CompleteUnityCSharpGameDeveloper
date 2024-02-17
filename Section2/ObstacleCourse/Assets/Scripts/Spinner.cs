using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float spinX = 0;
    [SerializeField] private float spinY = 0;
    [SerializeField] private float spinZ = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(spinX, spinY, spinZ);
    }
}
