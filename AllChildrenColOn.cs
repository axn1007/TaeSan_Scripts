using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllChildrenColOn : MonoBehaviour
{
    GameObject ai;
    MainAI mainAi;
    BoxCollider[] allBoxColChildren;
    SphereCollider[] allSphColChildren;
    CapsuleCollider[] allCapColChildren;
    MeshCollider[] allMeshColChildren;
    void Start()
    {
        ai = GameObject.Find("AI");
        mainAi = ai.GetComponent<MainAI>();

        allBoxColChildren = GetComponentsInChildren<BoxCollider>();
        allSphColChildren = GetComponentsInChildren<SphereCollider>();
        allCapColChildren = GetComponentsInChildren<CapsuleCollider>();
        allMeshColChildren = GetComponentsInChildren<MeshCollider>();

        foreach (BoxCollider child in allBoxColChildren)
        {
            child.gameObject.GetComponent<BoxCollider>().enabled = false;
        }

        foreach (SphereCollider child in allSphColChildren)
        {
            child.gameObject.GetComponent<SphereCollider>().enabled = false;
        }

        foreach (CapsuleCollider child in allCapColChildren)
        {
            child.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }

        foreach (MeshCollider child in allMeshColChildren)
        {
            child.gameObject.GetComponent<MeshCollider>().enabled = false;
        }
    }

    void Update()
    {
        float dist = Vector3.Distance(
            ai.transform.position,
            mainAi.wayPointBox[mainAi.wayPointBox.Length - 1].transform.position);

        if (dist < 0.025f)
        {
            foreach (BoxCollider child in allBoxColChildren)
            {
                child.gameObject.GetComponent<BoxCollider>().enabled = true;
            }

            foreach (SphereCollider child in allSphColChildren)
            {
                child.gameObject.GetComponent<SphereCollider>().enabled = true;
            }

            foreach (CapsuleCollider child in allCapColChildren)
            {
                child.gameObject.GetComponent<CapsuleCollider>().enabled = true;
            }

            foreach (MeshCollider child in allMeshColChildren)
            {
                child.gameObject.GetComponent<MeshCollider>().enabled = true;
            }
        }
    }
}
