using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // [SerializeField] private GameObject towerPrefab;
    [SerializeField] private Tower towerPrefab;

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
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            // Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlaceable = !isPlaced;
        }
    }
}
