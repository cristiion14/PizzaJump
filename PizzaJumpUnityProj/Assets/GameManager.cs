using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;
using TMPro;
public class GameManager : MonoBehaviour
{
    public SpriteRenderer backroundSprt;

    GameObject player;
    Color newColor;

    public Text scoreTxT;

  public  GridGraph grid;

    public bool gameOver = false;

    float multiplier = 0.00002f;

    

    void Awake()
    {
        player = GameObject.Find("Player");
        newColor = backroundSprt.color;

    }

    void Update()
    {

        
        //update the size of the graph grid
        int depth = (int)player.transform.position.y;
        // grid.depth = depth;
        //   grid.Scan();

        scoreTxT.text ="SCORE: "+Mathf.RoundToInt( player.transform.position.y).ToString();
        

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


        backroundSprt.color = newColor;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag =="Player")
        {
            Player player = other.collider.GetComponent<Player>();

        }
    }
}
