using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItenManager : MonoBehaviour
{
    [SerializeField] List<ItemData> items;
    public List<ItemData> filter_items;
    
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ItemCntUp(string findName)
    {
        filter_items = items.
            Where(n => n.itemName == findName).
            ToList();
        foreach(ItemData one in filter_items)
        {
            one.itemCount += 1;
            one.itemCountText.text = one.itemCount.ToString();
        }
    }

    public void FindGetItem()
    {
        filter_items = items.
            Where(n => n.itemCount > 0).
            ToList();
        foreach (ItemData one in filter_items)
        {
            Debug.Log("adsf");
            one.itemCover.SetActive(false);
        }
    }
}
