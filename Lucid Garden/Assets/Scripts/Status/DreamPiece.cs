using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DreamPiece : MonoBehaviour
{
    public int currentDP = 0;   //현재 갖고 있는 꿈의 조각
    public TextMeshProUGUI dpText;  //UI에 표시할 텍스트

    public void Awake()
    {
        UpdateDPText();
    }

    public void UpdateDPText()
    {
        dpText.text = FormatInt(currentDP);
    }

    public void AddDP(int dp)
    {
        currentDP += dp;
        UpdateDPText();
    }

    public void SubDP(int dp)
    {
        currentDP -= dp;
        UpdateDPText();
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
