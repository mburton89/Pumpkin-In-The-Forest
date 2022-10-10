using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public List<Item> Items = new List<Item>();

    public Transform itemContent;
    public GameObject inventoryItem;
    //public Dictionary<int, List<Item>> craftList = new Dictionary<int, List<Item>>();

    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);
            //var itemName  = obj.transform.Find("Item/ItemTitle").GetComponent<Text>();
            var itemIcon = obj.transform.Find("Icon").GetComponent<Image>();

            //itemName.text = item.title;
            itemIcon.sprite = item.icon;
        }

    }

    public bool containsItem(Item item)
    {
        bool found = false;

        for (int x = 0; x < itemSlots.length; x++)
        {

            if (itemSlots[x].Item = item)
            {
                found = true;
            }

        }

        return found;
    }

    public int itemCount(Item item)
    {
        int count = 0;

        for (int x = 0; x < itemSlots.length; x++)
        {
            
            if (itemSlots[x].Item = item)
            {
                count++;
            }

        }

        return count;
    }

    //private void LoadDictionary()
    //{
    //    craftList.Add(11, );
    
    //}

}
