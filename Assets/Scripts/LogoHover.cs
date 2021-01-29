using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoHover : MonoBehaviour
{
    private float hoverSpeed = 3f;
    private float localMax = 0.4f;
    private Vector3 currentObjectPos;
    // Start is called before the first frame update
    void Start()
    {
       currentObjectPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //get current gameobject position
        float y = Mathf.Sin(Time.time * hoverSpeed)*localMax+currentObjectPos.y;
        transform.position = new Vector3(currentObjectPos.x, y-2, currentObjectPos.z+25) * localMax;
        
    }
}
