using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float playerDamage;          //�÷��̾� ������
    public int weaponLevel;             //���ⷹ��
    public int enhancementCost;         //���Ⱝȭ ���
    public int enhancementPercentage;   //���Ⱝȭ Ȯ��

    public int gold;                    //���
    public bool isOnUI;                 //��ȭâ�̳� ����â�� �����ִ°�

    public TextMeshProUGUI goldText;    //ȭ�鿡 �������ִ� ��� �ؽ�Ʈ

    private void Update()
    {
        goldText.text = gold.ToString();//����ؽ�Ʈ ������Ʈ

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
