using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Tile> path = new List<Tile>();
    [SerializeField] [Range(0f, 5f)] private float speed = 2f;

    private Enemy enemy;
    
    //void Start()
    void OnEnable() 
    {
        //ImprimirWaypoints();
        FindPath();
        ReturnToStart();
        StartCoroutine(MoveInPath());
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
        path.Clear();
        //GameObject[] waypointsWorld = GameObject.FindGameObjectsWithTag("Path");
        //foreach(GameObject waypoint in waypointsWorld)

        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        foreach(Transform child in parent.transform)
        {
            path.Add(child.GetComponent<Tile>());
            Debug.Log("Just added: " + child.name);
        }
        //ImprimirWaypoints();
    }

    void ImprimirWaypoints()
    {
        foreach (Tile waypoint in path)
        {
            Debug.Log(waypoint.name);
        }
    }

    IEnumerator MoveInPath()
    {
        foreach (Tile waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
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
        transform.position = path[0].transform.position;
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }
    
    
}
