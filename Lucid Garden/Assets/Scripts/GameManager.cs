using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public StatusController statusManager;
    public MarketController marketManager;
    public QuickSlotController quickSlotManager;
    public CameraController cameraManager;
    public SeasonChange timeManager;

    public List<Vector2> boundPerLevel = new List<Vector2>();

    public int currentLevel = 0;

    private int ClickCount = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DataController.instance.LoadData();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LevelUp();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClickCount++;
            if (!IsInvoking("DoubleClick"))
                Invoke("DoubleClick", 1.0f);

        }
        else if (ClickCount == 2)
        {
            CancelInvoke("DoubleClick");
            DataController.instance.SaveData();
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Home))
        {
            DataController.instance.SaveData();
        }
        if (Input.GetKeyDown(KeyCode.Menu))
        {
            DataController.instance.SaveData();
        }
    }
    void DoubleClick()
    {
        ClickCount = 0;
    }

    public void LevelUp()
    {
        if (currentLevel + 1 > 5) return;
        currentLevel++;
        cameraManager.LevelUp(currentLevel);
    }
}
