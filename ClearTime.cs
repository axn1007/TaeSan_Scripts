using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearTime : MonoBehaviour
{
    //Timer timer;
    //Time[] times;


    public Text Ct;
    string times;


    void Start()
    {
        times = PlayerPrefs.GetString("TimerStop");
        Ct.text = times;
        print(Ct.text);
        //DontDestroyOnLoad(Ct);

    }


    void Update()
    {
        //Timer 스크립트 가져오기
        //timer = GameObject.Find("Timer").GetComponent<Timer>();
        //저장된 Timer 가져오기
        
    }
}
