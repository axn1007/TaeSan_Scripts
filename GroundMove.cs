using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    Vector3 dir;
    void Start()
    {
        dir = Vector3.right;
    }

    void Update()
    {
        transform.localPosition += dir * 2.5f * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        dir *= -1;
    }
}
