using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AI : MonoBehaviour
{
    GameObject targetP;
    public AIPath aiPath;
    GameObject GM;
    // Start is called before the first frame update
    void Start()
    {
        targetP = GameObject.Find("Player");
        GM = GameObject.Find("GM");
    }

    // Update is called once per frame
    void Update()
    {
        if (!GM.GetComponent<GameManager>().gameOver)
        {
            if (Vector2.Distance(transform.position, targetP.transform.position) < 1f)
            {
                float pHealth = targetP.GetComponent<Player>().getHealth();
                pHealth -= 10;
            }

            //snap the position of the sprite towards the moving direction

            //if its going right
            if (aiPath.desiredVelocity.x >= .01f)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            // going left
            else if (aiPath.desiredVelocity.x <= .01f)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);

            }
        }
    }
}
