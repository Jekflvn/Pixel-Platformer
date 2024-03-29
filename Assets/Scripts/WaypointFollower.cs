using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypoint = 0;
    [SerializeField] private float speed = 2f;
    private SpriteRenderer sprite;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(Vector2.Distance(waypoints[currentWaypoint].transform.position, transform.position ) < 0.1f){
            if(currentWaypoint == 0){
                currentWaypoint = 1;
            } else {
                currentWaypoint = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, Time.deltaTime * speed);
        if (currentWaypoint == 1){
            sprite.flipX = false;
        } else {
            sprite.flipX = true;
        }
    }
}
