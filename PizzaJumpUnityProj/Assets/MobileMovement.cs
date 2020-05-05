using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileMovement : MonoBehaviour
{
    Player player;
    Gyroscope gyro;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();   
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.gyro);
    }
}
