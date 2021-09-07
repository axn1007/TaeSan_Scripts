using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutObjActivity : MonoBehaviour
{
    GameObject ai;
    AIMove aiMove;
    public GameObject stageClearDummy;
    public GameObject balloon;
    public float balloonFinalSpd;
    bool balloonFinalEsc;
    void Start()
    {
        ai = GameObject.Find("AI");
        aiMove = ai.GetComponent<AIMove>();

        stageClearDummy.SetActive(false);
    }

    void Update()
    {
        float dist = Vector3.Distance(
           ai.transform.position,
           aiMove.wayPointBox[aiMove.wayPointBox.Length - 1].transform.position);
        if (dist < 0.025f)
        {
            stageClearDummy.SetActive(true);
            ai.SetActive(false);
            balloonFinalEsc = true;
        }

        if (balloonFinalEsc)
        {
            balloon.transform.position +=
                Vector3.up * balloonFinalSpd * Time.deltaTime;
        }
    }
}
