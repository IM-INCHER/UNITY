using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friendly : MonoBehaviour           //동료에 대한 스크립트
{
    public Monster monster;                     //몬스터 정보 받아옴
    public float damage;                        //동료 데미지
    public float attackDelay = 3.0f;            //동료 공격딜레이
    public int upgradeCost;                     //동료 업그레이드 비용
    public int level = 1;                       //동료 레벨

    public float maxAttackDelay;                //동료 최대 공격속도
    public float upgradeAttackDelay;            //업그레이드시 올라가는 공격속도
    public float addDamage;                     //업그레이드시 올라가는 공격력
    public int addUpgradeCost;                  //레벨이 오를시 올라가는 업글 가격

    public FriendMove friendMove;               //동료 애니메이션 스크립트

    float attackTime = 0.0f;                    //공격 주기 체크

    void Update()
    {
        if (Time.time > attackTime)             
        {
            attackTime = Time.time + attackDelay;
            Attack();
        }
    }
    public void Attack()
    {
        monster.currentMonsterHp = monster.currentMonsterHp - damage;
        friendMove.ClickAttak();
    }
    public void Upgrade()
    {
        level++;
        damage += addDamage;

        if(attackDelay >= maxAttackDelay && level % 5 == 0) attackDelay -= upgradeAttackDelay;

        upgradeCost += addUpgradeCost;
    }
}
