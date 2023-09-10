using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimation : MonoBehaviour
{
    Animator s_ani;

    void Start()
    {
        s_ani = GetComponent<Animator>();
    }

    void Update()
    {

    }
    public void ClickAttak()
    {
        s_ani.SetTrigger("isTouch");
    }
}

