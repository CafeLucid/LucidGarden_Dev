using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DPChatBubble : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    private void OnMouseDown()
    {
        Debug.Log("DPChatBubble OnMouseDown");
        GameManager.instance.statusManager.dreamPiece.AddDP(1);
        Hide();
    }
    public void OnClick()
    {
        Debug.Log("DPChatBubble OnClick");
        GameManager.instance.statusManager.dreamPiece.AddDP(1);
        Hide();
    }
}
