using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{

    public GameObject platformPrefab;
    GameObject newPlatform;

    void OnTriggerEnter2D(Collider2D other)
    {
        /*
        //Instatiate new platform
        newPlatform = (GameObject)Instantiate(platformPrefab, new Vector2(Random.Range(-4, 4), 
            GetComponentInParent<Player>().transform.position.y + (3.5f + Random.Range(0.5f, 1f))), Quaternion.identity);

        if(other.tag=="Ledge")
            Destroy(other.gameObject);
            */
        if(other.tag=="Ledge")
            other.transform.position = new Vector2(Random.Range(-4, 4), GetComponentInParent<Player>().transform.position.y +
            (3.5f + Random.Range(0.5f, 1f)));
    }
}
