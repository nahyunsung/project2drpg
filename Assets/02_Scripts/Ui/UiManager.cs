using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GameObject InteractionButton;

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
}
