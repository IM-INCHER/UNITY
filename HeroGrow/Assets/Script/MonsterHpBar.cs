using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHpBar : MonoBehaviour
{
    public Monster monster;
    public Slider hpBar;

    void Update()
    {
        hpBar.value = monster.currentMonsterHp / monster.maxMonsterHp;
    }
}
