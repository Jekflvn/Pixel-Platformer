using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollowerGroundEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypoint = 0;
    private SpriteRenderer sprite;
    [SerializeField] private float speed = 2f;
    private Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
    
        if(Vector2.Distance(waypoints[currentWaypoint].transform.position, transform.position ) < 0.5f){
            if(currentWaypoint == 0){
                currentWaypoint = 1;
            } else {
                currentWaypoint = 0;
            }
        }
        
        
        
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, Time.deltaTime * speed);
        
    }
}
