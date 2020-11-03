using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    public GameObject GM;  //reference to the game manager
    Vector3 spawnPos = new Vector3();



    // Destroying the platforms when the player has passed them
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ledge"  || other.tag == "BoostLedge")
        {
            // change the position of the ledges
            spawnPos.x = Random.Range(-GM.GetComponent<LevelGenerator>().levelWidth, GM.GetComponent<LevelGenerator>().levelWidth);
            spawnPos.y += GetComponentInParent<Player>().transform.position.y+  Random.Range(GM.GetComponent<LevelGenerator>().minY, GM.GetComponent<LevelGenerator>().maxY);

            other.gameObject.transform.position = spawnPos;
        }


    }

    
}
