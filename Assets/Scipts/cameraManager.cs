using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{
    public Transform target;
    public float cameraSpeed;

    void Update()
    {
        transform.position = Vector3.Slerp(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), cameraSpeed);
    }
}
