using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    public GameObject Ct;

    void Start()
    {
        //Ct = GameObject.Find("ClearTreeE").GetComponent<ClearTreeE>();
    }

    void Update()
    {
        if(Ct.transform.localScale.x >= 2 && Ct.transform.localScale.y >= 2 && Ct.transform.localScale.z >= 2)
        {
            SceneManager.LoadScene("ClearScene");
        }
    }
}
