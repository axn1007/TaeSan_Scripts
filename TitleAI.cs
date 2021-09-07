using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TitleAI : MonoBehaviour
{
    public GameObject goalBox;
    NavMeshAgent navi;
    TitleText titleText;
    void Start()
    {
        navi = GetComponent<NavMeshAgent>();
        titleText = GameObject.Find("TitleText").GetComponent<TitleText>();
    }

    void Update()
    {
        navi.SetDestination(goalBox.transform.position);
        float dist = Vector3.Distance(
            transform.position, goalBox.transform.position);
        if (dist < 1)
        {
            titleText.standby = true;
        }
    }
}
