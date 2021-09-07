using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{
    public Image btnStart;
    public Image btnTut;
    public Image btnExit;
    public Text btnStartText;
    public Text btnTutText;
    public Text btnExitText;
    public GameObject panel;
    Image panelFadeImg;
    [HideInInspector]
    public bool standby;
    float alpha = 0;
    float revAlpha = 1;

    private void Awake()
    {
        panelFadeImg = panel.GetComponent<Image>();
        panelFadeImg.color = new Color(0.0f, 0.0f, 0.0f, revAlpha);
    }
    void Update()
    {
        if (revAlpha >= 0.0f)
        {
            revAlpha -= 0.5f * Time.deltaTime;
            panelFadeImg.color = new Color(0.0f, 0.0f, 0.0f, revAlpha);
        }

        if (standby == true && alpha <= 1.0f)
        {
            alpha += 0.5f * Time.deltaTime;
            btnStart.color = new Color(1.0f, 1.0f, 1.0f, alpha);
            btnTut.color = new Color(1.0f, 1.0f, 1.0f, alpha);
            btnExit.color = new Color(1.0f, 1.0f, 1.0f, alpha);
            btnStartText.color = new Color(0.0f, 0.0f, 0.0f, alpha);
            btnTutText.color = new Color(0.0f, 0.0f, 0.0f, alpha);
            btnExitText.color = new Color(0.0f, 0.0f, 0.0f, alpha);

            if (alpha >= 1) panel.SetActive(false);
        }
    }

    public void OnClickStart()
    {
        SceneManager.LoadScene(2);
    }

    public void OnClickTut()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }
}
