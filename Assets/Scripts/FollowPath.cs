using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    //Get Reference from path. We need it for the path array. 
    [SerializeField]
    private Path _path;
    [Tooltip("A reference to a path with waypoints. ")]


    [SerializeField]
    private float _movementSpeed;
    [Tooltip("How fast the object is moving. ")]

    //Index to which the object is currently going towards. 
    private int waypointIndex = 0;
    void Update()
    {
        MoveToNextPath();
    }
    private void MoveToNextPath()
    {
        // Checks if the object hasn't reached the last checkpoint. 
        if (waypointIndex <= _path.Waypoints.Count - 1)
        {
            // Move Object from current waypoint to the next one.
            transform.position = Vector2.MoveTowards(transform.position,
               _path.Waypoints[waypointIndex].position,
               _movementSpeed * Time.deltaTime);

            // If the object hasn't reached the last waypoint, increase index by 1. 
            if (transform.position == _path.Waypoints[waypointIndex].position)
            {
                waypointIndex ++;
            }
        }
        // We can do an ELSE here. If it has reached the last path, player loses health/game over?
        // THEN we destroy/deactivate this object.
    }
}
