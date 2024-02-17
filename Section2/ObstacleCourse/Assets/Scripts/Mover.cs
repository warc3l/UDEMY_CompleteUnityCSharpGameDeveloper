using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float yValue = 0f;
    [SerializeField] private float moveSpeed = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {
        float xValue = moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        float zValue = moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.Translate(xValue, yValue, zValue);
    }
}
