using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendMove : MonoBehaviour
{
    Animator f_ani;
    void Start()
    {
        f_ani = GetComponent<Animator>();
    }

    public void ClickAttak()
    {
        f_ani.SetTrigger("isTouch");
    }

}
