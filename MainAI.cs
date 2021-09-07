using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MainAI : MonoBehaviour
{
    AudioSource eftSound;

    ArrowActivity arrowAct;

    public GameObject[] rayTarget;
    public GameObject[] wayPointBox;

    // Player Effect
    public GameObject leave;
    public GameObject smoke;

    RayManager rayManager;

    [HideInInspector]
    public NavMeshAgent navi;
    public int wpIndex;

    public enum AIState
    {
        Run,
        Idle,
    }

    public AIState state;
    public Animator anim;

    void Start()
    {
        eftSound = GameObject.Find("EftSound").GetComponent<AudioSource>();

        arrowAct = GameObject.Find("ArrowActivity").GetComponent<ArrowActivity>();
        // RayManager 스크립트 가져오기
        rayManager = GameObject.Find("RayManager").GetComponent<RayManager>();
        // Run 상태로 시작
        state = AIState.Run;
        // Animator 셋팅
        anim = GetComponent<Animator>();
        // Navigation 셋팅
        navi = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // 현재 상태에 따라 기능 수행
        switch (state)
        {
            case AIState.Run:
                Run();
                break;
            case AIState.Idle:
                Idle();
                break;
            default:
                break;
        }
        print(wpIndex);
    }

    void Run()
    {
        print("Run!!");
        navi.SetDestination(wayPointBox[wpIndex].transform.position);
        float dist = Vector3.Distance(
            transform.position, wayPointBox[wpIndex].transform.position);
        // 만약 목표지점과 가까워지면
        if (dist < 0.025f)
        {
            print("Access!!");
            leave.SetActive(false);
            smoke.SetActive(false);
            anim.SetTrigger("Idle");
            state = AIState.Idle;
        }
    }

    void Idle()
    {
        print("Stop!!");
        if (rayManager.hits.Length == 2)
        {
            if (rayManager.hits[0].transform.gameObject == rayTarget[wpIndex].gameObject ||
                rayManager.hits[1].transform.gameObject == rayTarget[wpIndex].gameObject)
            {
                eftSound.Play();
                leave.SetActive(true);
                smoke.SetActive(true);
                anim.SetTrigger("Run");
                state = AIState.Run;
                Destroy(rayManager.hits[0].transform.gameObject);
                Destroy(rayManager.hits[1].transform.gameObject);
                arrowAct.arrows[wpIndex].gameObject.SetActive(false);
                if (wpIndex < wayPointBox.Length - 1) wpIndex++;
            }
        }
    }
}
