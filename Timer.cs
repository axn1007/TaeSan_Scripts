using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    float time;
    float sec;
    float min;
    float hour;
    float currTime;
    bool isGameClear;
    public GameObject stageClearDummy;


    void Start()
    {
        currTime = Time.time;
    }

    void Update()
    {
        
        sec = (int)(Time.time - currTime);
        if(sec > 59)
        {
            currTime = Time.time;
            sec = 0;
            min++;

            if(min > 59)
            {
                min = 0;
                hour++;
            }
        }
        timerText.text = string.Format("Time : {0:00}:{1:00}:{2:00}", hour, min, sec);

        TimerStop();
        
    }

   
    void TimerStop()
    {
        //float dist = Vector3.Distance(ai.transform.position, mainAi.wayPointBox[mainAi.wayPointBox.Length - 1].transform.position);
       
        //AI가 Clear지점에 도착하면
        if (stageClearDummy.activeSelf == true)
        {
            //타이머 멈추기
            GetComponent<Timer>().enabled = false;
            SaveTime();
        }
        
    }

    public void SaveTime()
    {
        PlayerPrefs.SetString("TimerStop", timerText.text);
        print(PlayerPrefs.GetString("TimeStop"));
    }

}

