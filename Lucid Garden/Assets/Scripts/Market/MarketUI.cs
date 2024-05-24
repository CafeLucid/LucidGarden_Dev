using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketUI : MonoBehaviour
{
    public GameObject marketUI;
    public GameObject purchaseUI;
    private int selectedProductId = 0;

    public void Awake()
    {
        marketUI.SetActive(false);
        purchaseUI.SetActive(false);
    }

    public void Purchase(int id)
    {
        selectedProductId = id;
        if (GameManager.instance.marketManager.itemDB.GetItem(selectedProductId).Price <= GameManager.instance.statusManager.dreamPiece.currentDP)
        {
            purchaseUI.SetActive(true);
        }
    }

    public void PurchaseYes()
    {
        GameManager.instance.statusManager.dreamPiece.SubDP(GameManager.instance.marketManager.itemDB.GetItem(selectedProductId).Price);
        GameManager.instance.quickSlotManager.AddItem(selectedProductId, 1);
        purchaseUI.SetActive(false);
    }

    public void PurchaseNo()
    {
        purchaseUI.SetActive(false);
    }

    public void Show()
    {
        marketUI.SetActive(true);
        purchaseUI.SetActive(false);
    }

    public void Hide()
    {
        marketUI.SetActive(false);
        purchaseUI.SetActive(false);
    }
}
