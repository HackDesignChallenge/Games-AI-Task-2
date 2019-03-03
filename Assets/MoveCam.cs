using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public Transform target;

    public float smooth = 0.125f;
    public Vector3 offset;

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smooth);
            transform.position = smoothPosition;
        }
    }
}
