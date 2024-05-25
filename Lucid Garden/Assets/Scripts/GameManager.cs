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
    private void LevelUp()
    {
        if (currentLevel + 1 > 9) return;
        currentLevel++;
        if(currentLevel % 2 == 0) cameraManager.LevelUp(currentLevel/2);
    }
}
