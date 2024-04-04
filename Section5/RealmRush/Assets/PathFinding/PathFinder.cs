using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] private Vector2Int startCoordinates;
    [SerializeField] private Vector2Int endCoordinates;

    //[SerializeField] 
    private Node currentSearchNode;


    private Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();

    private Node startNode;
    private Node endNode;

    private Queue<Node> frontNodes = new Queue<Node>();


    private Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };

    private GridManager _gridManager;
    private Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();


    public Vector2Int EndCoordinates
    {
        get
        {
            return endCoordinates;
        }
    }
    
    public Vector2Int StartCoordinates
    {
        get { return startCoordinates;  }
    }



    private void Awake()
    {
        _gridManager = FindObjectOfType<GridManager>();
        if (_gridManager != null)
        {
            grid = _gridManager.Grid;
            startNode = grid[startCoordinates];
            endNode = grid[endCoordinates];
        }

        //startNode = new Node(startCoordinates, true);
        //endNode = new Node(endCoordinates, true);
    }

    private void Start()
    {
        // ExploreNeighs();
        GetNewPath();
    }

    public List<Node> GetNewPath()
    {
        _gridManager.ResetNodes();
        BFS();
        return BuildPath();
    }
    
    
    void ExploreNeighs()
    {
        List<Node> neighs = new List<Node>();
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborhood = currentSearchNode.coordinates + direction;
            // We would like to check if the direction is in the gridmanager or not...
            if (grid.ContainsKey(neighborhood))
            {
                neighs.Add(grid[neighborhood]);
                //Debug.Log("hola hola hola");
                //grid[neighborhood].isExplored = true;
//                grid[currentSearchNode].isPath = true;
            }
        }

        foreach (Node node in neighs)
        {
            if (!reached.ContainsKey(node.coordinates) && node.isWalkable)
            {
                node.connectedTo = currentSearchNode;
                reached.Add(node.coordinates, node);
                frontNodes.Enqueue(node);
            }
        }
    }

    private void BFS()
    {
        startNode.isWalkable = true;
        endNode.isWalkable = true;
        
        frontNodes.Clear(); // Clear the bFS
        reached.Clear();
        
        bool isRunning = true;
        frontNodes.Enqueue(startNode);
        reached.Add(startCoordinates, startNode);


        while (frontNodes.Count > 0 && isRunning)
        {
            currentSearchNode = frontNodes.Dequeue();
            currentSearchNode.isExplored = true;
            ExploreNeighs();
            if (currentSearchNode.coordinates == endCoordinates)
            {
                isRunning = false;
            }
        }
    }


    private List<Node> BuildPath()
    {
        List<Node> cami = new List<Node>();
        Node currentNode = endNode;
        
        cami.Add(currentNode);
        currentNode.isPath = true;

        while (currentNode.connectedTo != null)
        {
            Debug.Log("Constructing thepath....");
            currentNode = currentNode.connectedTo;
            cami.Add(currentNode);
            currentNode.isPath = true;
        }
        
        cami.Reverse();
        return cami;
    }

    public bool WillBlockThePath(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            bool previousState = grid[coordinates].isWalkable;
            grid[coordinates].isWalkable = false;

            List<Node> newPath = GetNewPath();
            grid[coordinates].isWalkable = previousState;

            if (newPath.Count <= 1)
            {
                GetNewPath();
                return true;
            }

            return false;
        }

        return false;
    }
    
}
