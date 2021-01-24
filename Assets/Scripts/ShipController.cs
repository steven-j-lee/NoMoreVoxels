using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float maxSpeed = 5;
    public float maxPitchSpeed = 3;
    public float maxTurnSpeed = 50;
    public float acceleration = 2;

    public float smoothSpeed = 3;
    public float smoothTurnSpeed = 3;

    Vector3 velocity;
    float yawVelocity;
    float pitchVelocity;
    float currentSpeed;


    //debug
    private Quaternion initialRotation = new Quaternion(0f, 0f, 0f, 0f);
    void Start()
    {
        currentSpeed = maxSpeed;

    }

    void Update()
    {
        float accelDir = 0;
        if (Input.GetKey(KeyCode.Q))
        {
            accelDir -= 1;
        }
        if (Input.GetKey(KeyCode.E))
        {
            accelDir += 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            currentSpeed = 20f;
            maxSpeed = 20f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            currentSpeed = 10f;
            maxSpeed = 10f;
        }

        currentSpeed += acceleration * Time.deltaTime * accelDir;
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        float speedPercent = currentSpeed / maxSpeed;

        Vector3 targetVelocity = transform.forward * currentSpeed;
        velocity = Vector3.Lerp(velocity, targetVelocity, Time.deltaTime * smoothSpeed);

        float targetPitchVelocity = Input.GetAxisRaw("Vertical") * maxPitchSpeed;
        pitchVelocity = Mathf.Lerp(pitchVelocity, targetPitchVelocity, Time.deltaTime * smoothTurnSpeed);

        float targetYawVelocity = Input.GetAxisRaw("Horizontal") * maxTurnSpeed;
        yawVelocity = Mathf.Lerp(yawVelocity, targetYawVelocity, Time.deltaTime * smoothTurnSpeed);
        transform.localEulerAngles += (Vector3.up * yawVelocity + Vector3.left * pitchVelocity) * Time.deltaTime * speedPercent;
        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);
    }

    void FixedUpdate()
    {
        //return back to initial position if hit by something
        if(gameObject.transform.rotation.z > 100f || gameObject.transform.rotation.z < -100f)
        {
            gameObject.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0f);
        }
    }
}