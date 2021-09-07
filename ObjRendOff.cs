using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjRendOff : MonoBehaviour
{
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    void Update()
    {
        
    }
}
