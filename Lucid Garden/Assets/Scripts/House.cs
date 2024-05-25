using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public float currentTime = 0f;
    public float chatBubbleTime = 300f;
    
    public DPChatBubble dreamPieceBubble;

    void Start()
    {
        dreamPieceBubble = GetComponentInChildren<DPChatBubble>();
        dreamPieceBubble.OnHappen += AfterBubble;
        dreamPieceBubble.Hide();
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= chatBubbleTime && !dreamPieceBubble.isActive)
        {
            dreamPieceBubble.Show();
            currentTime = 0;
        }
    }

    public void AfterBubble()
    {
        currentTime = 0;
    }
}
