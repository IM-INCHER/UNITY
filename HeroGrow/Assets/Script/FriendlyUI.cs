using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FriendlyUI : MonoBehaviour
{
    public GameManager GM;
    public SoundManager SM;

    public FriendlyManager FM;
    public GameObject fairyPanel;
    bool activeFriendly = false;
    bool activeSoldier = false;
    bool activeViking = false;
    bool activeWizard = false;

    public GameObject[] hireBtn;
    public GameObject[] upgradeBtn;
    public TextMeshProUGUI[] upgradeText;

    public void Start()
    {
        fairyPanel.SetActive(activeFriendly);
    }
    public void ClickButton()
    {
        if(GM.isOnUI == activeFriendly)
        {
            activeFriendly = !activeFriendly;
            GM.isOnUI = activeFriendly;
            fairyPanel.SetActive(activeFriendly);
        }
    }

    public void UpgradeSoldier()
    {
        if (activeSoldier)
        {
            if (GM.gold >= FM.friendlys[0].upgradeCost)
            {
                GM.gold -= FM.friendlys[0].upgradeCost;
                SM.AudioPlay(SM.UpgradeTrueSound);
                FM.friendlys[0].Upgrade();
                upgradeText[0].text = "업그레이드\n" + FM.friendlys[0].upgradeCost + "G";
            }
        }
    }
    public void UpgradeViking()
    {
        if (activeViking)
        {
            if (GM.gold >= FM.friendlys[1].upgradeCost)
            {
                GM.gold -= FM.friendlys[1].upgradeCost;
                SM.AudioPlay(SM.UpgradeTrueSound);
                FM.friendlys[1].Upgrade();
                upgradeText[1].text = "업그레이드\n" + FM.friendlys[1].upgradeCost + "G";

            }
        }

    }
    public void UpgradeWizard()
    {
        if (activeWizard)
        {
            if (GM.gold >= FM.friendlys[2].upgradeCost)
            {
                GM.gold -= FM.friendlys[2].upgradeCost;
                SM.AudioPlay(SM.UpgradeTrueSound);
                FM.friendlys[2].Upgrade();
                upgradeText[2].text = "업그레이드\n" + FM.friendlys[2].upgradeCost + "G";

            }
        }
    }

    public void HireSoldier()
    {
        if (GM.gold >= 1000)
        {
            GM.gold -= 1000;
            FM.friendlys[0].gameObject.SetActive(true);
            hireBtn[0].SetActive(false);
            upgradeBtn[0].SetActive(true);
            activeSoldier = true;
            SM.AudioPlay(SM.employSound);
        }
    }

    public void HireViking()
    {
        if (GM.gold >= 3000)
        {
            GM.gold -= 3000;
            FM.friendlys[1].gameObject.SetActive(true);
            hireBtn[1].SetActive(false);
            upgradeBtn[1].SetActive(true);
            activeViking = true;
            SM.AudioPlay(SM.employSound);
        }
    }

    public void HireWizard()
    {
        if (GM.gold >= 5000)
        {
            GM.gold -= 5000;
            FM.friendlys[2].gameObject.SetActive(true);
            hireBtn[2].SetActive(false);
            upgradeBtn[2].SetActive(true);
            activeWizard = true;
            SM.AudioPlay(SM.employSound);
        }
    }
}
