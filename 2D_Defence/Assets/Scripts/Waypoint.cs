using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
    [SerializeField]
    private Waypoint nextWaypoint;

    public Vector3 Getposition()
    {
        return transform.position;
    }

    public Waypoint GetNextWaypoint()
    {
        return nextWaypoint;
    }
}
