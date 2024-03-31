using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // [SerializeField] private GameObject towerPrefab;
    [SerializeField] private Tower towerPrefab;

    [SerializeField] private bool isPlaceable;
    private Vector2Int coordinates = new Vector2Int();

    private GridManager gridManager;
    private PathFinder pathFinder;

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathFinder = FindObjectOfType<PathFinder>();
    }

    private void Start()
    {
        if (gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
            if (!isPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }


    public bool IsPlaceable
    {
        get
        {
            return isPlaceable;
        }
    }
    
    private void OnMouseDown()
    {
        if (/* isPlaceable*/ gridManager.GetNode(coordinates).isWalkable && pathFinder.WillBlockThePath(coordinates) ) {
            Debug.Log(name);
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            // Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlaceable = !isPlaced;
            
            gridManager.BlockNode(coordinates);
        }
    }
}
