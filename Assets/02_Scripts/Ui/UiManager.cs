using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GameObject InteractionButton;
    public int stateNum;
    [SerializeField] public BigInteger my;
    public Text moneyText;
    GameData gmData;

    [SerializeField] private PlayerControllerExample plConExample;
    [SerializeField] private ItenManager itemManager;
    
    [SerializeField] private GameObject itemPanel;
    [SerializeField] private GameObject traningPanel;
    [SerializeField] private GameObject equipmentPanel;

    void Start()
    {
        gmData = GameObject.Find("GameData").GetComponent<GameData>();
        gmData.LoadData();
        MoneyText();
    }

    void Update()
    {
        
    }

    public void OnSaveButton()
    {
        gmData.SaveData(plConExample.playerLV, my,itemManager.ItemCntReturn());
    }

    public void InteractionButtonSetTrue()
    {
        InteractionButton.SetActive(true);
    }

    public void InteractionButtonSetFalse()
    {
        InteractionButton.SetActive(false);
    }

    public void OnInteractionButtonDown()
    {
        switch (stateNum)
        {
            case 0:
                traningPanel.SetActive(true);
                break;
            case 1:
                equipmentPanel.SetActive(true);
                break;
            case 2:
                itemPanel.SetActive(true);
                itemManager.FindGetItem();
                break;
            case 3:
                plConExample.SendMessage("DungeonGo");
                break;
            case 4:
                plConExample.SendMessage("DungeonExit");
                break;
            default:
                break;
        }
    }

    public void MoneyUp(float money)
    {
        my += (BigInteger)money;
        MoneyText();
    }

    public void MoneyText()
    {
        switch (my.ToString().Length)
        {
            case 1:
            case 2:
            case 3:
                moneyText.text = my.ToString();
                break;
            case 4:
            case 5:
            case 6:
                moneyText.text = (my / 1000).ToString() + "K";
                break;
            case 7:
            case 8:
            case 9:
                moneyText.text = (my / 1000000).ToString() + "M";
                break;
            case 11:
            case 12:
            case 10:
                moneyText.text = (my / 1000000000).ToString() + "B";
                break;
            case 13:
            case 14:
            case 15:
                moneyText.text = (my / 1000000000000).ToString() + "T";
                break;
            default:
                moneyText.text = (my.ToString())[0] + "." + (my.ToString())[1] + (my.ToString())[2] + "E" + "+" + ((my.ToString().Length) - 1);
                break;
        }
    }

    public void PlayerLvUp()
    {
        if(plConExample.playerLvUpMoney <= (float)my)
        {
            plConExample.playerLV += 1;
            my -= (BigInteger)plConExample.playerLvUpMoney;
            plConExample.PlayerDataCalculate();
            MoneyText();
        }
    }

    public void MoneyCopy()
    {
        my += 10000;
        MoneyText();
    }
}
