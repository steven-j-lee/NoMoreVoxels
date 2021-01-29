 using System;
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //variables for the laser
    public Transform bulletTransform;
    public Rigidbody bulletBody;

    public AudioClip laserSound;
    public AudioClip chargeSound;
    public AudioSource laserSource;
    
    //feature for laser charging
    public float minForce = 10f;
    public float maxForce = 30f;
    public float chargeRate = 0.5f;

    public float fireCoolDown;
    public float fireSpeed;

    public bool isFired;
    
    //variables for the player score
    public int playerScore = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        fireCoolDown = (maxForce - minForce) / chargeRate;
    }

    //init on each instance
    private void OnEnable()
    {
        fireSpeed = minForce;
    }

    // Update is called once per frame
    void Update()
    {
        //charging
        if (fireSpeed >= maxForce && !isFired)
        {
            fireSpeed = maxForce;
            Fire();

        }
        //initial fire action by the player
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            //if key is down fire
            isFired = false;
            fireSpeed = minForce;
            //play chargeSound
            laserSource.clip = chargeSound;
        }
        //still holding
        else if (Input.GetKey(KeyCode.Space) && !isFired)
        {
            fireSpeed += chargeRate * Time.deltaTime;
            
        } 
        //player fires the bullet
        else if (Input.GetKeyUp(KeyCode.Space) && !isFired)
        {
            Fire();

        }

    }

    private void Fire()
    {
        //instanciate bullet
        isFired = true;
        //instiate as a rigidbody
        Rigidbody laserInstance = Instantiate(bulletBody, bulletTransform.position,
        bulletTransform.rotation) as Rigidbody;
        //set velocity
        laserInstance.velocity = fireSpeed * bulletTransform.forward;
        //play sound
        laserSource.clip = laserSound;
        laserSource.Play();
        
        //reset speed
        fireSpeed = minForce;
        
    }
}
