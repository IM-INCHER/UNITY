using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Monster : MonoBehaviour
{
    public GameManager GM;
    public SoundManager SM;

    public float maxMonsterHp;
    public float currentMonsterHp;
    public int level;
    public int index;

    public GameObject[] monsterObj;
    public TextMeshPro monsterName;

    private void Start()
    {
        level = 1;
    }

    void Update()
    {
        if(currentMonsterHp <= 0)
        {
            DeadMonter();
        }
    }

    public void DeadMonter()
    {
        GM.gold += level * 100 + Random.Range((-10 * level), (10 * level));
        monsterObj[index].SetActive(false);
        index = Random.Range(0, monsterObj.Length);
        level++;

        MonsterRename(index);

        maxMonsterHp = level * 100;
        currentMonsterHp = maxMonsterHp;
        if(monsterObj.Length > 0)
        {
            monsterObj[index].SetActive(true);
        }

        SM.AudioPlay(SM.deathSound);
    }

    public void MonsterRename(int index)
    {
        switch (index)
        {
            case 0:
                monsterName.text = "LV." + level + " ΩΩ∂Û¿”";
                break;
            case 1:
                monsterName.text = "LV." + level + " ≈∑ΩΩ∂Û¿”";
                break;
            case 2:
                monsterName.text = "LV." + level + " ¡÷ø’¥´¿Ã";
                break;
            case 3:
                monsterName.text = "LV." + level + " ±Ë¡ÿºÆ";
                break;
        }
    }
}
