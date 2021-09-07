using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjActivity : MonoBehaviour
{
    public GameObject tornado;
    public GameObject balloon;
    public GameObject torAiDummy;
    public GameObject ballAiDummy;
    public GameObject branch;
    public GameObject bush;
    public bool tornadoToMidDest;
    bool tornadoToFinalDest;
    bool balloonToFinalDest;
    bool balloonToMidDest;
    bool bushGrow;
    public Transform tornadoMidPos;
    public Transform balloonOriginPos;
    public Transform balloonDestPos;
    public Transform balloonMidPos;
    public Transform overbridgeOriginPos;
    public Transform overbridgeDestPos;
    public float tornadoSpeed;
    public float balloonSpeed;
    AudioSource eftSound;
    RayManager rayManager;
    GameObject ai;
    MainAI mainAi;
    ArrowActivity arrowAct;

    void Start()
    {
        eftSound = GameObject.Find("EftSound").GetComponent<AudioSource>();

        arrowAct = GameObject.Find("ArrowActivity").GetComponent<ArrowActivity>();
        // ����̵� ��Ȱ��ȭ
        tornado.SetActive(false);
        // AIDummy ��Ȱ��ȭ
        torAiDummy.SetActive(false);
        ballAiDummy.SetActive(false);
        // RayManager ����
        rayManager = GameObject.Find("RayManager").GetComponent<RayManager>();
        // AI ����
        ai = GameObject.Find("AI");
        // MainAI ����
        mainAi = ai.GetComponent<MainAI>();
    }

    void Update()
    {
        print(bushGrow);

        // ���࿡ Ray�� ����Ǹ� Ȱ��ȭ
        if (rayManager.hits.Length == 2)
        {
            if (rayManager.hits[0].transform.CompareTag("TornadoBtn") &&
            rayManager.hits[1].transform.CompareTag("TornadoBtn") &&
            mainAi.wpIndex == 3 && mainAi.state == MainAI.AIState.Idle)
            {
                eftSound.Play();
                // ����̵� Ȱ��ȭ
                tornado.SetActive(true);
                // AIDummy Ȱ��ȭ
                torAiDummy.SetActive(true);

                mainAi.state = MainAI.AIState.Run;
                arrowAct.arrows[mainAi.wpIndex].gameObject.SetActive(false);
                mainAi.wpIndex++;
                Destroy(rayManager.hits[0].transform.gameObject);
                Destroy(rayManager.hits[1].transform.gameObject);

                // AI ��Ȱ��ȭ
                ai.SetActive(false);
                tornadoToMidDest = true;
            }

            else if (rayManager.hits[0].transform.CompareTag("BushBtn") &&
            rayManager.hits[1].transform.CompareTag("BushBtn") &&
            mainAi.wpIndex == 6 && mainAi.state == MainAI.AIState.Idle)
            {
                eftSound.Play();
                bushGrow = true;
                //mainAi.state = MainAI.AIState.Run;
                //mainAi.wpIndex++;
                Destroy(rayManager.hits[0].transform.gameObject);
                Destroy(rayManager.hits[1].transform.gameObject);
            }
        }

        if (tornadoToMidDest)
        {
            // �����ϸ� (�߰�����)
            if (Vector3.Distance(torAiDummy.transform.position,
                tornadoMidPos.position) < 0.025f)
            {
                tornadoToMidDest = false;
                tornadoToFinalDest = true;
            }
            // ��ǥ�������� �̵� (�߰�����)
            tornado.transform.position = Vector3.Slerp(
                tornado.transform.position,
                tornadoMidPos.position,
                tornadoSpeed);
        }
        else if (tornadoToFinalDest)
        {
            // �����ϸ� (��������)
            if (Vector3.Distance(torAiDummy.transform.position,
                mainAi.wayPointBox[4].transform.position) < 0.025f)
            {
                // �� �� ��Ȱ��
                tornado.SetActive(false);
                torAiDummy.SetActive(false);
                // ���� AI�� ��ġ ����
                ai.transform.position = mainAi.wayPointBox[4].transform.position;
                ai.SetActive(true);

                tornadoToFinalDest = false;
            }
            // ��ǥ�������� �̵� (��������)
            tornado.transform.position = Vector3.Slerp(
                tornado.transform.position,
                mainAi.wayPointBox[4].transform.position,
                tornadoSpeed);
        }

        if (Vector3.Distance(ai.transform.position,
            balloonOriginPos.position) < 0.025f)
        {
            ballAiDummy.SetActive(true);
            ai.SetActive(false);
            float balloonDist =
                Vector3.Distance(balloon.transform.position, balloonDestPos.position);
            balloon.transform.position =
                Vector3.Slerp(balloon.transform.position, balloonDestPos.position, balloonSpeed);
            if (balloonDist < 0.025f && ballAiDummy.activeSelf == true)
            {
                mainAi.wayPointBox[5].transform.position = overbridgeOriginPos.position;
                ai.transform.position = balloon.transform.position;
                ballAiDummy.SetActive(false);
                ai.SetActive(true);
                mainAi.leave.SetActive(true);
                mainAi.smoke.SetActive(true);
                mainAi.state = MainAI.AIState.Run;
                balloonToMidDest = true;
            }
        }

        if (balloonToMidDest)
        {
            if (Vector3.Distance(balloon.transform.position, balloonMidPos.position) < 0.025f)
            {
                balloonToMidDest = false;
                balloonToFinalDest = true;
            }
            balloon.transform.position =
                Vector3.Slerp(balloon.transform.position,
                balloonMidPos.position,
                balloonSpeed);
        }
        else if (balloonToFinalDest)
        {
            balloon.transform.position =
                Vector3.Slerp(balloon.transform.position,
                mainAi.wayPointBox[mainAi.wayPointBox.Length - 1].transform.position,
                balloonSpeed);
        }

        if (bushGrow)
        {
            if (bush.transform.localScale.x <= 1 &&
                bush.transform.localScale.y <= 1 &&
                bush.transform.localScale.z <= 1)
            {
                bush.transform.localScale += new Vector3(0.7f, 0.7f, 0.7f) * Time.deltaTime;
            }
            if (branch.transform.localScale.x >= 0.1f &&
                branch.transform.localScale.y >= 0.1f &&
                branch.transform.localScale.z >= 0.1f)
            {
                branch.transform.localScale -= new Vector3(0.7f, 0.7f, 0.7f) * Time.deltaTime;
            }
        }
    }
}
