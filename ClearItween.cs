using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearItween : MonoBehaviour
{
    public GameObject target;

    void Start()
    {
        iTween.MoveBy(target, iTween.Hash("y", -200, "easetype", iTween.EaseType.easeOutBounce));
    }

    void Update()
    {
        
    }
}
