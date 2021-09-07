using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleText : MonoBehaviour
{
    public Text titleText;
    [HideInInspector]
    public bool standby;
    float alpha = 0;
    TitleUI titleUI;

    private void Start()
    {
        titleUI = GameObject.Find("UIManager").GetComponent<TitleUI>();
    }
    void Update()
    {
        if (standby == true && alpha <= 1.0f)
        {
            alpha += 0.5f * Time.deltaTime;
            titleText.color = new Color(0.0f, 1.0f, 0.0f, alpha);
            if (alpha >= 1) titleUI.standby = true;
        }
    }
}
