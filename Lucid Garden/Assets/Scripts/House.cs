using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public float currentTime = 0f;
    public float chatBubbleTime = 5f;

    public DPChatBubble dreamPieceBubble;

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= chatBubbleTime && !dreamPieceBubble.isActive)
        {
            dreamPieceBubble.Show();
            currentTime = 0;
        }
    }
}
