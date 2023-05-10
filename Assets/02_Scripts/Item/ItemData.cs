using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public class ItemData
{
    [SerializeField] public string itemName;
    [SerializeField] public int itemCount;
    [SerializeField] public Text itemCountText;
    [SerializeField] public GameObject itemCover;

}
