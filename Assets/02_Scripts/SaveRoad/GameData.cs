using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Numerics;
using System.IO;

[Serializable]
public class PlayerData
{
    public int playerLV;
    public string gold;

    public void GetData()
    {
        PlayerControllerExample plConEx = GameObject.Find("character").GetComponent<PlayerControllerExample>();
        UiManager uiManager = GameObject.Find("UiManager").GetComponent<UiManager>();
        plConEx.playerLV = playerLV;
        uiManager.my = BigInteger.Parse(gold);
    }
}

public class GameData : MonoBehaviour
{
    private void Start()
    {
        
    }
    public void SaveData(int playerLv, BigInteger gold)
    {
        PlayerData myData = new PlayerData();
        myData.playerLV = playerLv;
        myData.gold = gold.ToString();

        string str = JsonUtility.ToJson(myData);

        Debug.Log(str);
        string path = Path.Combine(Application.persistentDataPath + "/PlayerData.json");
        Debug.Log(path);
        File.WriteAllText(path, JsonUtility.ToJson(myData));

    }

    public void LoadData()
    {
        try
        {
            string jsonData = File.ReadAllText(Application.persistentDataPath + "/PlayerData.json");
            PlayerData myData = JsonUtility.FromJson<PlayerData>(jsonData);
            myData.GetData();
        }
        catch(Exception ex)
        {
            SaveData(1, 0);
        }
    }
}
