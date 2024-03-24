using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] private float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        ImprimirWaypoints();
        StartCoroutine(PrintWaypoint());
    }

    void ImprimirWaypoints()
    {
        foreach (Waypoint waypoint in path)
        {
            Debug.Log(waypoint.name);
        }
    }

    IEnumerator PrintWaypoint()
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
            //yield return new WaitForSeconds(waitTime);
        }
    }
    
    
}
