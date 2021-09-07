using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutArrowActivity : MonoBehaviour
{
    public GameObject[] arrows;
    int arrowSizeDir = 1;
    GameObject ai;
    AIMove aiMove;

    void Start()
    {
        ai = GameObject.Find("AI");
        aiMove = ai.GetComponent<AIMove>();
        for (int i = 0; i < arrows.Length; i++)
        {
            arrows[i].SetActive(false);
        }
    }

    void Update()
    {
        arrows[aiMove.wpIndex].gameObject.SetActive(true);

        if (arrows[aiMove.wpIndex].gameObject.transform.localScale.x >= 1.5f ||
            arrows[aiMove.wpIndex].gameObject.transform.localScale.x <= 1.0f)
        {
            arrowSizeDir *= -1;
        }

        arrows[aiMove.wpIndex].gameObject.transform.localScale +=
            new Vector3(0.8f, 0.8f, 0) * arrowSizeDir * Time.deltaTime;
    }
}
