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

    public List<Vector2> boundPerLevel = new List<Vector2>();

    public int currentLevel = 0;

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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        if (currentLevel + 1 > 4) return;
        currentLevel++;
        cameraManager.LevelUp(currentLevel);
    }
}
