using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPasser : MonoBehaviour
{
    AudioSource eftSound;
    TutArrowActivity arrowAct;
    AIMove aiMove;
    GameObject ai;
    void Start()
    {
        eftSound = GameObject.Find("EftSound").GetComponent<AudioSource>();
        arrowAct = GameObject.Find("ArrowActivity").GetComponent<TutArrowActivity>();
        ai = GameObject.Find("AI");
        aiMove = ai.GetComponent<AIMove>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (aiMove.state == AIMove.AIState.Idle && ai.activeSelf == true)
            {
                eftSound.Play();
                aiMove.leave.SetActive(true);
                aiMove.smoke.SetActive(true);
                arrowAct.arrows[aiMove.wpIndex].gameObject.SetActive(false);
                aiMove.wpIndex++;
                aiMove.anim.SetTrigger("Run");
                aiMove.state = AIMove.AIState.Run;
            }
        }
    }
}
