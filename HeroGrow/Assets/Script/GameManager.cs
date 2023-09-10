using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float playerDamage;          //플레이어 데미지
    public int weaponLevel;             //무기레벨
    public int enhancementCost;         //무기강화 비용
    public int enhancementPercentage;   //무기강화 확률

    public int gold;                    //골드
    public bool isOnUI;                 //강화창이나 동료창이 켜져있는가

    public TextMeshProUGUI goldText;    //화면에 가지고있는 골드 텍스트

    private void Update()
    {
        goldText.text = gold.ToString();//골드텍스트 업데이트

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
    }

    private void Start()
    {
        SetResolution();
        isOnUI = false;                 
        enhancementCost = 100;
        enhancementPercentage = 80;
    }

    private void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void SetResolution()
    {
        int setWidth = 1600;
        int setHeight = 1000;

        Screen.SetResolution(setWidth, setHeight, false);
    }
}
