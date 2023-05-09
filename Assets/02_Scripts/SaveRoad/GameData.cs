using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[Serializable]
public class PlayerData
{
    public int playerLV;
    public int gold;

    public void GetData()
    {
        Debug.Log("playerLV : " + playerLV);
        // 데이터 대입
    }
}

public class GameData : MonoBehaviour
{
    void Start()
    {
        SaveData();
    }

    public void SaveData()
    {
        PlayerData myData = new PlayerData();
        myData.playerLV = 10;
        myData.gold = 12;

        string str = JsonUtility.ToJson(myData);

        Debug.Log(str);
        string path = Path.Combine(Application.persistentDataPath + "/PlayerData.json");
        Debug.Log(path);
        File.WriteAllText(path, JsonUtility.ToJson(myData));

    }

    public void LoadData()
    {
        string jsonData = File.ReadAllText(Application.persistentDataPath + "/PlayerData.json");

        PlayerData myData = JsonUtility.FromJson<PlayerData>(jsonData);
        myData.GetData();
    }
}
