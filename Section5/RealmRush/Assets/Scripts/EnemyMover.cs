using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Waypoint> path = new List<Waypoint>();
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
            path.Add(child.GetComponent<Waypoint>());
            Debug.Log("Just added: " + child.name);
        }
        //ImprimirWaypoints();
    }

    void ImprimirWaypoints()
    {
        foreach (Waypoint waypoint in path)
        {
            Debug.Log(waypoint.name);
        }
    }

    IEnumerator MoveInPath()
    {
        foreach (Waypoint waypoint in path)
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
        
        enemy.StealGold();
        gameObject.SetActive(false);
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }
    
    
}
