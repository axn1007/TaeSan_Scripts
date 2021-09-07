using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutUIManager : MonoBehaviour
{
    GameObject clear;
    GameObject help;
    ClearTreeEft clearTreeEft;

    void Start()
    {
        clearTreeEft = GameObject.Find("ClearTreeE").GetComponent<ClearTreeEft>();
        clear = GameObject.Find("Clear");
        clear.SetActive(false);
        help = GameObject.Find("Help");
    }

    void Update()
    {
        if (clearTreeEft.transform.localScale.x >= 2)
            clear.SetActive(true);
    }

    public void OnClickGoMain()
    {
        SceneManager.LoadScene(2);
    }

    public void OnClickGoTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void OnClickHelpOff()
    {
        help.SetActive(false);
    }
}
