using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnManager : MonoBehaviour
{
    //유저 이름
    public InputField nameInput;

    public GameObject roomInfoFactory;

    public Transform content;

    public Text ct;

    public void CreateNameList()
    {
        if(nameInput.text.Length > 0)
        {
            //roomInfo버튼 공장에서 roomInfo버튼 생성
            GameObject name = Instantiate(roomInfoFactory);
            //만들어진 roomInfo버튼을 content의 자식으로 셋팅
            name.transform.SetParent(content);
            //만들어진 roomInfo버튼에서 roomInfoBtn 컴포넌트 가져오기
            RoomInfoBtn btn = name.GetComponent<RoomInfoBtn>();
            //가져온 컴포넌트의 SetInfo 함수 호출
            btn.SetInfo(nameInput.text, ct.text);
        }
    }

}

