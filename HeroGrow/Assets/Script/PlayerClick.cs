using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClick : MonoBehaviour
{
    public GameManager GM;
    public Monster monseter;
    public SoundManager SM;
    public WeaponAnimation WeaponAni;

    private void OnMouseDown()
    {
        if(!GM.isOnUI)
        {
            monseter.currentMonsterHp = monseter.currentMonsterHp - GM.playerDamage;
            SM.AudioPlay(SM.attackSound);
            WeaponAni.ClickAttak();
        }
    }
}
