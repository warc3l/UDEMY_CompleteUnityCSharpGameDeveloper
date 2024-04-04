using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    //[SerializeField] private List<Tile> path = new List<Tile>();
    private List<Node> path = new List<Node>();
    [SerializeField] [Range(0f, 5f)] private float speed = 2f;
    

    private Enemy enemy;

    private GridManager gridManager;
    private PathFinder pathFinder;
    
    
    //void Start()
    void OnEnable() 
    {
        //ImprimirWaypoints();
        FindPath();
        ReturnToStart();
        StartCoroutine(MoveInPath());
    }

    //private void Start()
    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        pathFinder = FindObjectOfType<PathFinder>();
        gridManager = FindObjectOfType<GridManager>();
    }

    void FindPath()
    {
        path.Clear();
        path = pathFinder.GetNewPath();
        
        
        //GameObject[] waypointsWorld = GameObject.FindGameObjectsWithTag("Path");
        //foreach(GameObject waypoint in waypointsWorld)

        // GameObject parent = GameObject.FindGameObjectWithTag("Path");
        // foreach(Transform child in parent.transform)
        // {
        //     path.Add(child.GetComponent<Tile>());
        //     Debug.Log("Just added: " + child.name);
        // }
        // //ImprimirWaypoints();
    }

    void ImprimirWaypoints()
    {
        foreach (Node waypoint in path)
        {
            Debug.Log(waypoint.coordinates);
        }
    }

    IEnumerator MoveInPath()
    {
        for (int i = 0; i < path.Count; i++)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = gridManager.GetPositionFromCoordinates(path[i].coordinates); // waypoint.transform.position;
            float percentTravel = 0f;
            transform.LookAt(endPosition);
            while (percentTravel < 1f)
            {
                percentTravel += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, percentTravel);
                yield return new WaitForEndOfFrame();
            }
            // Debug.Log(waypoint.name);
            //transform.position = waypoint.transform.position;
            //yield return new WaitForSeconds(1.0f);
            // Destroy(gameObject);
        }

        FinishPath();
    }

    void ReturnToStart()
    {
        transform.position = gridManager.GetPositionFromCoordinates(pathFinder.StartCoordinates); //path[0].transform.position;
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }
    
    
}
