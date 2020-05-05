using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SpriteRenderer backroundSprt;

    GameObject player;
    Color newColor;

    float multiplier = 0.00002f;
    void Awake()
    {
        player = GameObject.Find("Player");
        newColor = backroundSprt.color;
    }

    void Update()
    {
        multiplier = player.transform.position.y/1000000;
        if (newColor.a <= 1)
        {
            newColor.a = player.transform.position.y / 200;
        }
         else if(newColor.g != 0)
        {
            newColor.g -= multiplier;
        }
        else if(newColor.g <=0)
        {
            newColor.r -= multiplier;
        }

        Debug.Log(newColor.g);
        backroundSprt.color = newColor;
    }
}
