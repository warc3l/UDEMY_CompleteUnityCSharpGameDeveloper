using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    [SerializeField] private float timeToDestroy = 3f;
    void Start()
    {
        Destroy(gameObject, timeToDestroy);        
    }
}
