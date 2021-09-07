using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnManager : MonoBehaviour
{
    //���� �̸�
    public InputField nameInput;

    public GameObject roomInfoFactory;

    public Transform content;

    public Text ct;

    public void CreateNameList()
    {
        if(nameInput.text.Length > 0)
        {
            //roomInfo��ư ���忡�� roomInfo��ư ����
            GameObject name = Instantiate(roomInfoFactory);
            //������� roomInfo��ư�� content�� �ڽ����� ����
            name.transform.SetParent(content);
            //������� roomInfo��ư���� roomInfoBtn ������Ʈ ��������
            RoomInfoBtn btn = name.GetComponent<RoomInfoBtn>();
            //������ ������Ʈ�� SetInfo �Լ� ȣ��
            btn.SetInfo(nameInput.text, ct.text);
        }
    }

}

