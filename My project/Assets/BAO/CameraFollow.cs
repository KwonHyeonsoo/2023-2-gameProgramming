using UnityEngine;
using System.Collections;


public class CameraFollow : MonoBehaviour
{
    public Transform target;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + new Vector3(0f, 3f, -6f);
        transform.position = desiredPosition;
        transform.LookAt(target);
    }
}