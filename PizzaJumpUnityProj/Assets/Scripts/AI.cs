using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AI : MonoBehaviour
{
	//This code is taking care of the enemy pathfinding 
	
    GameObject targetP;
    GameObject GM;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    Path path;
    int currentWaypoint = 0;
    bool reachEndPath = false;

    

    Seeker seeker;
    Rigidbody2D enemyRB;

    GameObject monsterGFX;
    // Start is called before the first frame update
    void Start()
    {
        targetP = GameObject.Find("Player");
        GM = GameObject.Find("GM");
        seeker = GetComponent<Seeker>();
        enemyRB = GetComponent<Rigidbody2D>();

        //generate path
        InvokeRepeating("UpdatePath", 0f, .5f);

         monsterGFX = GameObject.Find("MonsterAnim");
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void UpdatePath()
    {
        if(seeker.IsDone())
        seeker.StartPath(enemyRB.position, targetP.transform.position, OnPathComplete);

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //check to see if a path is available
        if (path == null)
        {
            return;
        }

        //check to see if there are more waypoints or not to stop the player when neccessary
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachEndPath = true;
            return;
        }
        else
        {
            reachEndPath = false;
        }

        //move the enemy
        //get the direction to the next waypoint
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - enemyRB.position).normalized;
        
        //get a direction force to be applied on the enemy 
        Vector2 force = direction * speed * Time.deltaTime;

        //add force
        enemyRB.AddForce(force);

        //distance to next waypoint
        float distance = (enemyRB.position - new Vector2(path.vectorPath[currentWaypoint].x, path.vectorPath[currentWaypoint].y)).sqrMagnitude;

        if (distance < nextWaypointDistance*nextWaypointDistance)
            currentWaypoint++;

        //snap the position of the sprite towards the moving direction
        //if its going right
        if (force.x > 0)
           monsterGFX.transform.localScale = new Vector3(-1f, 1f, 1f);

        // going left
        else if (force.x < 0)
           monsterGFX.transform.localScale = new Vector3(1f, 1f, 1f);
        
    }
}

