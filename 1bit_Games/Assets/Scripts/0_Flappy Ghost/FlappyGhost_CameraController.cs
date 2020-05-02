using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyGhost_CameraController : MonoBehaviour
{
    private Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if(target.position.x>transform.position.x)
            transform.position = new Vector3(target.position.x, transform.position.y, -10);
    }
}
