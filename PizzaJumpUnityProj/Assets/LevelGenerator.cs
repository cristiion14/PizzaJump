using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    GameObject player;
    List<GameObject> instantiatedPlatform = new List<GameObject>();
    public Transform firstPlatformPos;

    public int numberOfPlatforms = 100;
    public float levelWidth = 5f;
    public float minY = .8f;
    public float maxY = 1.5f;

    int instantiatePos = 1;
    Vector3 spawnPos = new Vector3();


    void Start()
    {
        player = GameObject.Find("Player");

        instantiatedPlatform.Add(Instantiate(platformPrefab, firstPlatformPos.position, Quaternion.identity));
        instantiatedPlatform.Add(Instantiate(platformPrefab, firstPlatformPos.position + new Vector3(Random.Range(-levelWidth, levelWidth), Random.Range(minY, maxY),0), Quaternion.identity));
        instantiatedPlatform.Add(Instantiate(platformPrefab, firstPlatformPos.position + new Vector3(Random.Range(-levelWidth, levelWidth), Random.Range(minY, maxY),0), Quaternion.identity));
        instantiatedPlatform.Add(Instantiate(platformPrefab, firstPlatformPos.position + new Vector3(Random.Range(-levelWidth, levelWidth), Random.Range(minY, maxY),0), Quaternion.identity));
        instantiatedPlatform.Add(Instantiate(platformPrefab, firstPlatformPos.position + new Vector3(Random.Range(-levelWidth, levelWidth), Random.Range(minY, maxY),0), Quaternion.identity));
        instantiatedPlatform.Add(Instantiate(platformPrefab, firstPlatformPos.position + new Vector3(Random.Range(-levelWidth, levelWidth), Random.Range(minY, maxY),0), Quaternion.identity));


        // Vector3 lastSpawnPos = new Vector3();
        // Debug.Log(spawnPos.x);
        /*
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            
            spawnPos.x = Random.Range(-levelWidth, levelWidth);
            spawnPos.y += Random.Range(minY, maxY);

            Instantiate(platformPrefab, spawnPos, Quaternion.identity);
            lastSpawnPos = spawnPos;

        }
        */


    }

    int i = 0;
    void Update()
    {
        //Procedural Instantiating of platforms
        if (player.GetComponent<Player>().hasJumped)
        {
            spawnPos.x = Random.Range(-levelWidth, levelWidth);
            spawnPos.y += Random.Range(minY, maxY);
           instantiatedPlatform.Add( Instantiate(platformPrefab, spawnPos, Quaternion.identity));
           instantiatedPlatform.Add( Instantiate(platformPrefab, spawnPos, Quaternion.identity));
           instantiatedPlatform.Add( Instantiate(platformPrefab, spawnPos, Quaternion.identity));
           instantiatedPlatform.Add( Instantiate(platformPrefab, spawnPos, Quaternion.identity));
            instantiatePos += 3;

            Destroy(instantiatedPlatform[i]);
            i++;
     //       Debug.LogError("i is: "+i);
        }
    

    }
}
