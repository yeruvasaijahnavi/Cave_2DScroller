using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 cameraOffset;
    public float smoothSpeed=0.9f;


    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 finalPosition = playerTransform.position + cameraOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, finalPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
