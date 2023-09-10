using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JinsimPanel : MonoBehaviour
{
    public int clickcount = 0;
    public float limitTime = 5;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI upText;

    void Start()
    {
        
    }
    void Update()
    {
        limitTime -= Time.deltaTime;
        timeText.text = "Time : " + limitTime.ToString("N2");
        upText.text = "Áõ°¡ÇÑ È®·ü : " + UpPercentage();
    }

    public void Click()
    {
        clickcount++;
    }

    public int UpPercentage()
    {
        int num = Mathf.FloorToInt((float)clickcount / 2.5f);

        if (num > 20) num = 20;

        return num;
    }

    public bool TimeOver()
    {
        if(limitTime <= 0 ) return true;

        return false;
    }
}
