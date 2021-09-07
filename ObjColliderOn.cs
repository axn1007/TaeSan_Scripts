using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjColliderOn : MonoBehaviour
{
    GameObject ai;
    AIMove aiMove;
    void Start()
    {
        ai = GameObject.Find("AI");
        aiMove = ai.GetComponent<AIMove>();
        GetComponent<MeshCollider>().enabled = false;
    }

    void Update()
    {
        float dist = Vector3.Distance(
            ai.transform.position,
            aiMove.wayPointBox[aiMove.wayPointBox.Length - 1].transform.position);
        if (dist < 0.025f)
        {
            GetComponent<MeshCollider>().enabled = true;
        }
    }
}
