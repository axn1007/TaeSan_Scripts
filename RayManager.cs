using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayManager : MonoBehaviour
{
    public RaycastHit[] hits;

    void Start()
    {

    }

    void Update()
    {
        int layer = 1 << LayerMask.NameToLayer("Event");
        hits = Physics.RaycastAll(
            Camera.main.transform.position,
            Camera.main.transform.forward,
            50, layer);
        //if (hits.Length == 2)
        //{
        //    print("2");
        //}
        //else
        //{
        //    print("0");
        //}
        //foreach (RaycastHit hit in hits)
        //{
        //    Debug.Log("Raycast!");
        //}
    }
}
