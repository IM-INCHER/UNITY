using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friendly : MonoBehaviour           //���ῡ ���� ��ũ��Ʈ
{
    public Monster monster;                     //���� ���� �޾ƿ�
    public float damage;                        //���� ������
    public float attackDelay = 3.0f;            //���� ���ݵ�����
    public int upgradeCost;                     //���� ���׷��̵� ���
    public int level = 1;                       //���� ����

    public float maxAttackDelay;                //���� �ִ� ���ݼӵ�
    public float upgradeAttackDelay;            //���׷��̵�� �ö󰡴� ���ݼӵ�
    public float addDamage;                     //���׷��̵�� �ö󰡴� ���ݷ�
    public int addUpgradeCost;                  //������ ������ �ö󰡴� ���� ����

    public FriendMove friendMove;               //���� �ִϸ��̼� ��ũ��Ʈ

    float attackTime = 0.0f;                    //���� �ֱ� üũ

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
