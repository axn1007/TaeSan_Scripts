using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class NameBtn : MonoBehaviour
{
    public Label name;

    void OnClick()
    {
        string convertName = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(name.text));
        PlayerPrefs.SetString("Name", convertName);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
