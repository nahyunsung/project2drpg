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

    public void ItemCntRoad(List<int> itemCnt)
    {
        for(int i = 0; i < itemCnt.Count; i++)
        {
            items[i].itemCount = itemCnt[i];
            items[i].itemCountText.text = itemCnt[i].ToString();
        }
    }

    public List<int> ItemCntReturn()
    {
        List<int> itemsCnt = new List<int>();
        foreach (ItemData one in items)
        {
            itemsCnt.Add(one.itemCount);
        }
        return itemsCnt;
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
            one.itemCover.SetActive(false);
        }
    }
}
