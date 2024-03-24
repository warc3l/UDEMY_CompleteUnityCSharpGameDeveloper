using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private bool isPlaceable;

    public bool IsPlaceable
    {
        get
        {
            return isPlaceable;
        }
    }
    
    private void OnMouseDown()
    {
        if (isPlaceable) {
            Debug.Log(name);
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
    }
}
