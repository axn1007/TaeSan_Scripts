using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomInfoBtn : MonoBehaviour
{
    //클릭되었을 때 호출되는 함수
    public Action<String> clickAction;
    //정보를 보여줄 텍스트
    public Text info;
    //이름
    string name;

    string times;

    void Start()
    {
        GameObject.Find("ClearTime").GetComponent<ClearTime>();
    }

    //정보셋팅
    public void SetInfo(string userName, string clearTime)
    {
        name = userName;
        info.text = "이름" + "  " + ":" + " " + userName + " " + "=>" + "  "+"Clear" +" "+ clearTime;
    }

    public void OnClick()
    {
        if(clickAction != null)
        {
            clickAction(name);
        }
    }
}