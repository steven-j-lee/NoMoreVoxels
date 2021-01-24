using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform follower;
    public Vector3 offset;

    //values
    public float lookAt = 10f;
    public float time = 0.5f;
    public float smoothness = 5f;

    public Vector3 smoothVector;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPos = follower.position + follower.forward * offset.z 
            + follower.up * offset.y + follower.right * offset.x;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref smoothVector, time);

        Quaternion rot = transform.rotation;
        transform.LookAt(follower.position + follower.forward * lookAt);
        Quaternion targetRot = transform.rotation;

        transform.rotation = Quaternion.Slerp(rot, targetRot, Time.deltaTime * smoothness);
    }
}
