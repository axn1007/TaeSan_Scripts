using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomInfoBtn : MonoBehaviour
{
    //Ŭ���Ǿ��� �� ȣ��Ǵ� �Լ�
    public Action<String> clickAction;
    //������ ������ �ؽ�Ʈ
    public Text info;
    //�̸�
    string name;

    string times;

    void Start()
    {
        GameObject.Find("ClearTime").GetComponent<ClearTime>();
    }

    //��������
    public void SetInfo(string userName, string clearTime)
    {
        name = userName;
        info.text = "�̸�" + "  " + ":" + " " + userName + " " + "=>" + "  "+"Clear" +" "+ clearTime;
    }

    public void OnClick()
    {
        if(clickAction != null)
        {
            clickAction(name);
        }
    }
}