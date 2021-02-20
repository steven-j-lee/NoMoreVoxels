using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bunny : MonoBehaviour
{
    private GameObject player;
    private float prevTime;
    private Vector3 movementDir;
    


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            other.GetComponent<ShipController>().isGameOver = true;
        }
        if (other.tag.Equals("Bullet"))
        {
            player.GetComponent<ShipController>().playerScore += 100;
            Destroy(this.gameObject);
        }
    }
}
