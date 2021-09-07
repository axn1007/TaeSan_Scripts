using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointPasser : MonoBehaviour
{
    AudioSource eftSound;
    ArrowActivity arrowAct;
    MainAI mainAi;
    GameObject ai;
    ObjActivity objAct;
    AIPosManager aiPosMng;
    void Start()
    {
        eftSound = GameObject.Find("EftSound").GetComponent<AudioSource>();
        arrowAct = GameObject.Find("ArrowActivity").GetComponent<ArrowActivity>();
        ai = GameObject.Find("AI");
        mainAi = ai.GetComponent<MainAI>();
        objAct = GameObject.Find("ObjActivity").GetComponent<ObjActivity>();
        aiPosMng = GameObject.Find("AIPosManager").GetComponent<AIPosManager>();
    }

    void Update()
    {
        print(aiPosMng.posIndex);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (mainAi.wpIndex == 5 && mainAi.state == MainAI.AIState.Idle)
            {
                eftSound.Play();
                if (ai.activeSelf == true && aiPosMng.posIndex == 0)
                {
                    ai.SetActive(false);
                }

                if (aiPosMng.posIndex < aiPosMng.aiPoss.Length - 1)
                {
                    aiPosMng.aiPoss[aiPosMng.posIndex].SetActive(false);
                    aiPosMng.rayTargets[aiPosMng.posIndex].SetActive(false);
                    aiPosMng.posIndex++;
                    aiPosMng.aiPoss[aiPosMng.posIndex].SetActive(true);
                }

                if (aiPosMng.aiPoss[aiPosMng.aiPoss.Length - 1].activeSelf == true)
                {
                    ai.transform.position = aiPosMng.overbridgeDestPos.position;
                    ai.SetActive(true);
                    mainAi.leave.SetActive(true);
                    mainAi.smoke.SetActive(true);
                    arrowAct.arrows[mainAi.wpIndex].gameObject.SetActive(false);
                    mainAi.wpIndex++;
                    mainAi.state = MainAI.AIState.Run;
                    aiPosMng.aiPoss[aiPosMng.aiPoss.Length - 1].SetActive(false);
                }
            }

            else if (mainAi.wpIndex == 3 && mainAi.state == MainAI.AIState.Idle && ai.activeSelf == true)
            {
                eftSound.Play();
                mainAi.leave.SetActive(true);
                mainAi.smoke.SetActive(true);
                arrowAct.arrows[mainAi.wpIndex].gameObject.SetActive(false);
                mainAi.wpIndex++;
                // 토네이도 활성화
                objAct.tornado.SetActive(true);
                // AIDummy 활성화
                objAct.torAiDummy.SetActive(true);
                // AI 비활성화
                mainAi.anim.SetTrigger("Run");
                mainAi.state = MainAI.AIState.Run;
                ai.SetActive(false);
                objAct.tornadoToMidDest = true;
            }

            else if (mainAi.state == MainAI.AIState.Idle && ai.activeSelf == true)
            {
                eftSound.Play();
                mainAi.leave.SetActive(true);
                mainAi.smoke.SetActive(true);
                arrowAct.arrows[mainAi.wpIndex].gameObject.SetActive(false);
                mainAi.wpIndex++;
                mainAi.anim.SetTrigger("Run");
                mainAi.state = MainAI.AIState.Run;
            }
        }
    }
}
