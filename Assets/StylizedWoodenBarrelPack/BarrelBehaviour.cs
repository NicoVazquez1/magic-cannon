using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBehaviour : MonoBehaviour
{
    public Transform[] waypoints;  
    public float speed = 2.5f;      

    private int currentWaypointIndex = 0;   // Index of the current waypoint

    private void Start()
    {
        GameObject[] waypointObjects = GameObject.FindGameObjectsWithTag("waypoint");
        waypoints = new Transform[waypointObjects.Length];
        for (int i = 0; i < waypointObjects.Length; i++)
        {
            waypoints[i] = waypointObjects[i].transform;
        }

        // Set the initial position of the target to the position of the first waypoint
        transform.position = waypoints[currentWaypointIndex].position;
    }

    private void Update()
    {
        // Move the target towards the current waypoint
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);

        // Check if the target has reached the current waypoint
        if (transform.position == waypoints[currentWaypointIndex].position)
        {
            // Move to the next waypoint
            currentWaypointIndex++;

            // If all waypoints have been visited, reset to the first waypoint
            if (currentWaypointIndex >= waypoints.Length)
                currentWaypointIndex = 0;
        }
    }
}
