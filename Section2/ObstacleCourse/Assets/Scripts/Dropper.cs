using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] private float timeToWait = 2.0f;

    private MeshRenderer myMeshRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        myMeshRenderer = GetComponent<MeshRenderer>();         
        myMeshRenderer.enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeToWait)
        {
            Debug.Log("Time elapsed");
            myMeshRenderer.enabled = true;
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
