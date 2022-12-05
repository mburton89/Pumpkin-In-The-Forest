using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;
public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public List<Item> ItemsList = new List<Item>();

    public Transform itemContent;
    public GameObject inventoryItem;
    //public Dictionary<int, List<Item>> craftList = new Dictionary<int, List<Item>>();

    private TextMeshPro tempText;

    void Awake()
    {
        instance = this;
    }

    public void Add(Item item)
    {
        ItemsList.Add(item);
    }

    public void Remove(Item item)
    {
        ItemsList.Remove(item);
    }

    public void ListItems()
    {
        //destroys previous instances so no duplicates
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }

        List<Item> ItemHolder = new List<Item>();

        foreach (var item in ItemsList)
        {
            if (!ItemHolder.Contains(item))
            {
                GameObject obj = Instantiate(inventoryItem, itemContent);
                //var itemName  = obj.transform.Find("Item/ItemTitle").GetComponent<Text>();
                var itemIcon = obj.transform.Find("Icon").GetComponent<Image>();
                var numberOfItemsText = obj.transform.Find("Count").GetComponent<TMP_Text>();

                int numberOfItems = itemCount(item);

                numberOfItemsText.SetText(numberOfItems == 1 ? "" : ("" + numberOfItems));

                //itemName.text = item.title;
                itemIcon.sprite = item.icon;

                //temp.SetText("1");
                //temp.transform.SetParent(obj.transform);

                ItemHolder.Add(item);
            }

            
        }

    }

    public bool containsItem(Item searchItem)
    {
        bool found = false;

        foreach (var item in ItemsList)
        {

            if (item.id == searchItem.id)
            {
                found = true;
            }

        }

        return found;
    }

    public int itemCount(Item searchItem)
    {
        int count = 0;

        foreach (var item in ItemsList)
        {

            if (item.id == searchItem.id)
            {
                count++;
            }

        }

        Debug.Log("counting items");

        return count;
    }

}
