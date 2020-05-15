using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using Unity.Profiling;
public class LevelGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    GameObject player;
  public  List<GameObject> instantiatedPlatform = new List<GameObject>();
    public Transform firstPlatformPos;

    public int numberOfPlatforms = 100;
    public float levelWidth = 2.8f;
    public float minY = .2f;
    public float maxY = 1.5f;
    
    int instantiatePosD = 1;
    Vector3 spawnPos = new Vector3();

   // static ProfilerMarker start = new ProfilerMarker("LevelGenerating.Prepare");
    //static ProfilerMarker end   = new ProfilerMarker("LevelGenerating.Simuate");


    CustomSampler sampler;
    GameObject lastPlatform;
    Recorder profilerRec;

    void Start()
    {
        InstantiatePlaftorms(numberOfPlatforms, Vector2.zero);

    }
       

        
        //   Profiler.EndSample();



        /*
        instantiatedPlatform.Add(Instantiate(platformPrefab, firstPlatformPos.position, Quaternion.identity));
        instantiatedPlatform.Add(Instantiate(platformPrefab, firstPlatformPos.position + new Vector3(Random.Range(-levelWidth, levelWidth), Random.Range(minY, maxY),0), Quaternion.identity));
        instantiatedPlatform.Add(Instantiate(platformPrefab, firstPlatformPos.position + new Vector3(Random.Range(-levelWidth, levelWidth), Random.Range(minY, maxY),0), Quaternion.identity));
        instantiatedPlatform.Add(Instantiate(platformPrefab, firstPlatformPos.position + new Vector3(Random.Range(-levelWidth, levelWidth), Random.Range(minY, maxY),0), Quaternion.identity));
        instantiatedPlatform.Add(Instantiate(platformPrefab, firstPlatformPos.position + new Vector3(Random.Range(-levelWidth, levelWidth), Random.Range(minY, maxY),0), Quaternion.identity));
        instantiatedPlatform.Add(Instantiate(platformPrefab, firstPlatformPos.position + new Vector3(Random.Range(-levelWidth, levelWidth), Random.Range(minY, maxY),0), Quaternion.identity));
        */

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


    public void InstantiatePlaftorms(int numberOfPlatforms, Vector2 lastPos)
    {
        sampler = CustomSampler.Create("InstantiatingFunction");

        //begining of profiling
        sampler.Begin();

        //position to instantiate
        Vector3 instantiatePos = new Vector3();
        instantiatePos.y = lastPos.y;
        //loop through the number of wanted platforms and instantiate it
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            instantiatePos.x = Random.Range(-levelWidth, levelWidth);
            instantiatePos.y += Random.Range(minY, maxY);

            instantiatedPlatform.Add ( Instantiate(platformPrefab, instantiatePos, Quaternion.identity));

            if (i == numberOfPlatforms - 1)
                instantiatedPlatform[i].name = "lastPlatform";
        }
        //end area of the profiler
        sampler.End();
    }
    int x = 0;
    void Update()
    {
        /*
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

          //  Destroy(instantiatedPlatform[i]);
            i++;
     //       Debug.LogError("i is: "+i);
        }
        
        
    */
    
    }
    
}
