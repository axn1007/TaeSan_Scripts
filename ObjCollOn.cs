using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjCollOn : MonoBehaviour
{
    GameObject ai;
    MainAI mainAi;

    void Start()
    {
        ai = GameObject.Find("AI");
        mainAi = ai.GetComponent<MainAI>();
        GetComponentInChildren<MeshCollider>().enabled = false;
    }

    void Update()
    {
        float dist = Vector3.Distance(
            ai.transform.position,
            mainAi.wayPointBox[mainAi.wayPointBox.Length - 1].transform.position);

        if(dist < 0.025f)
        {
            GetComponent<MeshCollider>().enabled = true;
        }
    }
}
