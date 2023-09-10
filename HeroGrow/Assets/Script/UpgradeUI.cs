using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeUI : MonoBehaviour
{
    public GameManager GM;
    public SoundManager SM;

    public GameObject upgradePanel;
    public JinsimPanel jinsimPanel;
    public bool activeUpgrad = false;
    public bool activePercentageUp = false;

    public TextMeshProUGUI weaponInfo;
    public TextMeshProUGUI upgradeInfo;
    public TextMeshProUGUI nomalBtnText;
    public TextMeshProUGUI jinsimBtnText;



    private void Start()
    {
        upgradePanel.SetActive(activeUpgrad);
        jinsimPanel.gameObject.SetActive(activePercentageUp);
    }

    private void Update()
    {
        if(activePercentageUp)
        {
            if(jinsimPanel.TimeOver())
            {
                Enhancement(jinsimPanel.UpPercentage());
                activePercentageUp = false;
                jinsimPanel.gameObject.SetActive(activePercentageUp);
            }
        }
    }

    public void ClickButton()
    {
        if (GM.isOnUI == activeUpgrad)
        {
            activeUpgrad = !activeUpgrad;
            GM.isOnUI = activeUpgrad;
            upgradePanel.SetActive(activeUpgrad);

            if (activeUpgrad == true)
            {
                UpdateInfo();
            }
        }
    }

    public void NomalUp()
    {
        if(GM.gold >= GM.enhancementCost)
        {
            GM.gold -= GM.enhancementCost;

            Enhancement(0);
        }
    }

    public void JinsimUp()
    {
        if (GM.gold >= GM.enhancementCost)
        {
            GM.gold -= GM.enhancementCost;

            activePercentageUp = true;
            jinsimPanel.clickcount = 0;
            jinsimPanel.limitTime = 5.0f;
            jinsimPanel.gameObject.SetActive(activePercentageUp);
            SM.AudioPlay(SM.UpgradeSound);
        }
    }

    public void EnhancementSuccess()
    {
        GM.weaponLevel++;
        GM.enhancementCost = GM.weaponLevel * ((GM.weaponLevel >= 10) ? (GM.weaponLevel / 10 * 500) : 500);
        GM.playerDamage += GM.weaponLevel;

        if (GM.enhancementPercentage > 20) GM.enhancementPercentage -= 5;

        SM.AudioPlay(SM.UpgradeTrueSound);

        UpdateInfo();
    }

    public void EnhancementFailed()
    {
        SM.AudioPlay(SM.UpgradeFalseSound);
    }

    public void Enhancement(int up)
    {
        int rand = Random.Range(0, 101);
        if (rand <= GM.enhancementPercentage + up)
            EnhancementSuccess();
        else
            EnhancementFailed();
    }

    public void UpdateInfo()
    {
        weaponInfo.text = "검 +" + GM.weaponLevel.ToString() + "\n공격력 : " + GM.playerDamage.ToString();
        upgradeInfo.text = "공격력 : " + (GM.playerDamage + GM.weaponLevel).ToString() + "\n강화확률 : " + GM.enhancementPercentage.ToString() + "%" +
            " ~ " + (GM.enhancementPercentage + 20).ToString() + "%\n강화비용 : " + GM.enhancementCost.ToString() + "G";

        nomalBtnText.text = "그냥 강화하기\n" + GM.enhancementPercentage + "%";
        jinsimBtnText.text = "힘내서 강화하기\n" + GM.enhancementPercentage + "% ~ " + (GM.enhancementPercentage + 20) + "%";
    }
}

