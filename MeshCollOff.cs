using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCollOff : MonoBehaviour
{
    //MeshCollider[] objList;

    void Start()
    {
        GetComponent<MeshCollider>().enabled = false;

        //for(int i = 0; i < objList.Length; i++)
        //{
        //    objList[i].gameObject.SetActive(false);
        //}

        //MeshCollider[] objList = (MeshCollider[])gameObject.GetComponentsInChildren(typeof(MeshCollider));
        //foreach(object child in objList)
        //{
        //    GetComponent<MeshCollider>().enabled = false;
        //}
    }

    void Update()
    {
        
    }
}
