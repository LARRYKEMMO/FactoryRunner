using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform whoToFollow;
    [SerializeField] private Vector3 offset;
    void Update()
    {
        transform.position = whoToFollow.position + offset;

    }

}
