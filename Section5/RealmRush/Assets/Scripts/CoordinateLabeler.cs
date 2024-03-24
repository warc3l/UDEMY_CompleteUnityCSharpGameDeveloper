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
    private TextMeshPro label;
    private Waypoint waypoint;
    
    // We can get the world coordinate
    private Vector2Int coordinates = new Vector2Int();
    
    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        waypoint = GetComponentInParent<Waypoint>();
        MostraCoordenadesEnEditMode();
    }        
    
    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            MostraCoordenadesEnEditMode();
            ActualitzaNom();
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
        label.color = waypoint.IsPlaceable ? defaultColor : blockedColor;
    }
    
    void MostraCoordenadesEnEditMode()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z); 
        label.text = coordinates.x + "," + coordinates.y;
    }

    void ActualitzaNom()
    {
        transform.parent.name = coordinates.ToString();
    }
    
}
