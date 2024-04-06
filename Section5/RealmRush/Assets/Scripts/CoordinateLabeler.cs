using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] private Color defaultColor = Color.black;
    [SerializeField] private Color blockedColor = Color.blue;

    // Using the GridManager...:
    [SerializeField] private Color exploredColor = Color.yellow;
    [SerializeField] private Color pathColor = new Color(1f, 0.5f, 0f); // orange
    
    private TextMeshPro label;
    private Tile _tile;

    private GridManager gridManager;
    
    
    // We can get the world coordinate
    private Vector2Int coordinates = new Vector2Int();
    
    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        _tile = GetComponentInParent<Tile>();
        
        // Using a GridManager and not Waypoint
        gridManager = FindObjectOfType<GridManager>();
        
        
        MostraCoordenadesEnEditMode();
    }        
    
    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            MostraCoordenadesEnEditMode();
            ActualitzaNom();
            label.enabled = true;
        }
        
        // Color coordinates
        ColorCoordinates();
        ToggleColors();

    }

    void ToggleColors()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    private void ColorCoordinates()
    {
        if (gridManager == null) return;
        Node node = gridManager.GetNode(coordinates);

        if (node == null) { return;}
        
        if (!node.isWalkable)
        {
            label.color = blockedColor;
        } else if (node.isPath)
        {
            label.color = pathColor;
        } else if (node.isExplored)
        {
            label.color = exploredColor;
        }
        else
        {
            label.color = defaultColor;
        }


        return; // We are using GridManager. Remove to use Waypoints.
        label.color = _tile.IsPlaceable ? defaultColor : blockedColor;
    }
    
    void MostraCoordenadesEnEditMode()
    {
        if (gridManager == null) return;
        
        
        // coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        // coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z); 

        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / gridManager.UnityGridSize);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / gridManager.UnityGridSize); 

        
        label.text = coordinates.x + "," + coordinates.y;
    }

    void ActualitzaNom()
    {
        transform.parent.name = coordinates.ToString();
    }
    
}
