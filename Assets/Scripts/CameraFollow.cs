using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject followingObject;

    private void Start()
    {
        followingObject
    }
    private void FixedUpdate()
    {
        transform.position = followingObject.transform.position;   
    }
}
