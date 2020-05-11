using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverGM : MonoBehaviour
{
    bool hasPressedRestart = false;
    public Text score;
    GameObject player;
    public GameObject gameOverCanvas;
    public GameObject panel;
    void Awake()
    {
        player = GameObject.Find("Player");

        gameOverCanvas.SetActive(false);
    }

    void DisableComponents()
    {
        //  Time.timeScale = 0;
        gameOverCanvas.SetActive(true);
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        panel.SetActive(false);
    }

    void Update()
    {
        if (player.GetComponent<Player>().gameOver)
        {
            DisableComponents();

            if (Input.GetMouseButtonDown(0))
                SceneManager.LoadScene(1);

        }

        score.text ="HIGHSCORE: "+ Mathf.RoundToInt( player.GetComponent<Player>().topScore).ToString();

    }

}
