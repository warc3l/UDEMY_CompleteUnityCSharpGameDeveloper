using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GridManager : MonoBehaviour
{
//    [SerializeField] private Node node;
    [SerializeField] private Vector2Int gridSize;
    private Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    [FormerlySerializedAs("worldGridSize")]
    [Tooltip("UnityEditor.EditorSnapSettings.move.x should match with this")]
    [SerializeField] private int unityGridSize;
    
    public int UnityGridSize
    {
        get { return unityGridSize;  }
    }
    
    private void Awake()
    {
        CrearGrid();
    }

    public Node GetNode(Vector2Int coordinates)
    {
        Node result = null;
        grid.TryGetValue(coordinates, out result);
        return result;
    }

    public Dictionary<Vector2Int, Node> Grid
    {
        get
        {
            return grid;
        }
    }
    
    
    private void CrearGrid()
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector2Int coordinates = new Vector2Int(x, y);
                grid.Add(coordinates, new Node(coordinates, true));
                
                Debug.Log(grid[coordinates].coordinates + " = " + grid[coordinates].isWalkable);
            }
        }
    }

    public void BlockNode(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            grid[coordinates].isWalkable = false;
        }
    }

    public Vector2Int GetCoordinatesFromPosition(Vector3 position)
    {
        Vector2Int result = new Vector2Int();
        
        result.x = Mathf.RoundToInt(position.x / unityGridSize);
        result.y = Mathf.RoundToInt(position.z/ unityGridSize);

        return result;
    }
    
    public Vector3 GetPositionFromCoordinates(Vector2Int coordinates)
    {
        Vector3 result = new Vector3();
        result.x = coordinates.x * unityGridSize;
        result.z = coordinates.y * unityGridSize;

        return result;
    }
    
    public void ResetNodes()
    {
        foreach (var entry in grid)
        {
            entry.Value.connectedTo = null;
            entry.Value.isExplored = false;
            entry.Value.isPath = false;
        }
    }



}
