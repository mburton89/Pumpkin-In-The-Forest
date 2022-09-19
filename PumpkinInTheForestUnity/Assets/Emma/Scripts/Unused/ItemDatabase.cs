using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    private void Awake()
    {
        BuildDatabase();
    }

    public Item GetItem(string title)
    {
        return items.Find(item => item.title == title);
    }

    void BuildDatabase()
    {
        items = new List<Item>()
        {
            new Item
            (
                0,
                "Twig",
                "A twig. Not much else."
            )

        };

    }
}

