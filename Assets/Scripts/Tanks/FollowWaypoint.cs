using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoint : MonoBehaviour
{

    public Transform[] waypoints;
    int currentWaypoint;
    public float speed = 5.0f;
    public float rotationspeed = 3.0f;
    GameObject tracker;
    float lookAhead = 10.0f;
    public Transform cannon; 
    public Transform player;
    


    void Start()
    {
        tracker = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        DestroyImmediate(tracker.GetComponent<Collider>());
        tracker.GetComponent<MeshRenderer>().enabled = false;
        tracker.transform.position = transform.position;
        tracker.transform.rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {


        ProgressTracker();
        
        Vector3 lookDirection = tracker.transform.position - transform.position;
        Quaternion lookAtWaypoint = Quaternion.LookRotation(lookDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookAtWaypoint, Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }

    void ProgressTracker()
    {

        // Se o tracker ainda não chegou suficientemente perto do player, não mudar de waypoint
        if (Vector3.Distance(tracker.transform.position, transform.position) > lookAhead)
        {
            return;
        }

        // Verifica se o tracker atingiu o waypoint atual e então muda para o próximo waypoint
        if (Vector3.Distance(waypoints[currentWaypoint].position, tracker.transform.position) < 0.5f)
        {
            currentWaypoint = currentWaypoint >= waypoints.Length - 1 ? 0 : currentWaypoint + 1;
        }

        // Calcula a direção para o próximo waypoint
        Vector3 direction = (waypoints[currentWaypoint].position - tracker.transform.position).normalized;

        // Move o tracker na direção do próximo waypoint
        tracker.transform.Translate(direction * (speed * 2) * Time.deltaTime, Space.World);
    }

    

    
}