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
        //Timer ��ũ��Ʈ ��������
        //timer = GameObject.Find("Timer").GetComponent<Timer>();
        //����� Timer ��������
        
    }
}
