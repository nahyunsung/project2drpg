using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GameObject InteractionButton;
    public int stateNum;

    void Start()
    {
        
    }

    void Update()
    {
        
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
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                GameObject.FindWithTag("Player").GetComponent<PlayerControllerExample>().SendMessage("DungeonGo");
                break;
            default:
                break;
        }
    }
}
