using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Happiness : MonoBehaviour
{
    public int currentHappy = 0;   //현재 행복도
    public TextMeshProUGUI happyText;  //UI에 표시할 텍스트

    public void Awake()
    {
        UpdateHappyText();
    }

    public void UpdateHappyText()
    {
        happyText.text = FormatInt(currentHappy);
    }

    public void AddHappy(int happy)
    {
        currentHappy += happy;
        UpdateHappyText();
        if(currentHappy == 100 || currentHappy == 300 || currentHappy == 700 || currentHappy == 1500)
        {
            GameManager.instance.LevelUp();
        }
    }

    public void SubHappy(int happy)
    {
        currentHappy -= happy;
        UpdateHappyText();
    }

    string FormatInt(int value)
    {
        if (value == 0)
        {
            return "0";
        }
        return string.Format("{0:#,###}", value);
    }
}
