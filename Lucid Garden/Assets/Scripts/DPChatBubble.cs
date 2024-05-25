using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DPChatBubble : MonoBehaviour
{
    public bool isActive;
    public Action OnHappen;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 0f);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                GameManager.instance.statusManager.dreamPiece.AddDP(10);
                Hide();
            }
        }
    }
    public void Show()
    {
        isActive = true;
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        isActive = false;
        OnHappen?.Invoke();
        gameObject.SetActive(false);
    }
}
