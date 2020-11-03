using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
	//This class is taking care of shooting mechanics
    public GameObject projectile;
    public GameObject impactEffect;
    int fireRate = 5;
    int damage = 20;
    int nextTimeToFire = 0;
    int range = 10;

   public Vector3 direction;
    void Update()
    {
       
        if(Input.GetMouseButtonDown(0) && Time.time>nextTimeToFire)
        {
            direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);


           // nextTimeToFire += 3;
            direction.z = 0;

            Shoot();
        }
        
        if (Input.GetKeyDown(KeyCode.L))
            Shoot();

    }
    
 
  
    void Shoot()
    {
        if (Time.timeScale > 0)
        {
            //sound effect
            GetComponent<AudioSource>().clip = GetComponent<Player>().hitSound;
            GetComponent<AudioSource>().Play();
            //instantiate the effect
            GameObject shootEffect = Instantiate(projectile, transform.position, Quaternion.identity);
        }

    }
    
}
