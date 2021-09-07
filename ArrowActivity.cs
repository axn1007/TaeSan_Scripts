using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowActivity : MonoBehaviour
{
    public GameObject[] arrows;
    int arrowSizeDir = 1;
    GameObject ai;
    MainAI mainAi;

    void Start()
    {
        ai = GameObject.Find("AI");
        mainAi = ai.GetComponent<MainAI>();
        for (int i = 0; i < arrows.Length; i++)
        {
            arrows[i].SetActive(false);
        }
    }

    void Update()
    {
        arrows[mainAi.wpIndex].gameObject.SetActive(true);

        if (arrows[mainAi.wpIndex].gameObject.transform.localScale.x >= 1.5f ||
            arrows[mainAi.wpIndex].gameObject.transform.localScale.x <= 1.0f)
        {
            arrowSizeDir *= -1;
        }

        arrows[mainAi.wpIndex].gameObject.transform.localScale +=
            new Vector3(0.8f, 0.8f, 0) * arrowSizeDir * Time.deltaTime;
    }
}
