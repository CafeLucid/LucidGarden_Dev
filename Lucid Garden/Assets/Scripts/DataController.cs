using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class PlayerData
{
    public int level;
    public int happiness;
    public int dreamPiece;
    public List<int> id = new List<int>();
    public List<int> amount = new List<int>();
}
public class DataController : MonoBehaviour
{
    public static DataController instance;
    PlayerData playerData = new PlayerData();
    string path;
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
        DontDestroyOnLoad(gameObject);
        path = Application.persistentDataPath + "/PlayerData.json";
    }
    public void SaveData()
    {
        playerData.level = GameManager.instance.currentLevel;
        playerData.happiness = GameManager.instance.statusManager.happiness.currentHappy;
        playerData.dreamPiece = GameManager.instance.statusManager.dreamPiece.currentDP;
        playerData.id = new List<int>(GameManager.instance.quickSlotManager.items.Keys);
        playerData.amount = new List<int>(GameManager.instance.quickSlotManager.items.Values);

        string data = JsonUtility.ToJson(playerData);
        File.WriteAllText(path, data);
    }
    public void LoadData()
    {
        if (File.Exists(path))
        {
            string data = File.ReadAllText(path);
            playerData = JsonUtility.FromJson<PlayerData>(data);
            GameManager.instance.currentLevel = playerData.level;
            GameManager.instance.statusManager.happiness.currentHappy = playerData.happiness;
            GameManager.instance.statusManager.dreamPiece.currentDP = playerData.dreamPiece;
            for (int i = 0; i < playerData.id.Count; i++)
            {
                GameManager.instance.quickSlotManager.items.Add(playerData.id[i], playerData.amount[i]);
            }
            GameManager.instance.quickSlotManager.UpdateItemCount();
            GameManager.instance.statusManager.dreamPiece.UpdateDPText();
            GameManager.instance.statusManager.happiness.UpdateHappyText();
            GameManager.instance.cameraManager.RemoveBlocks();
        }
    }
}
