using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, player.transform.position.y, -15);
    }
}
