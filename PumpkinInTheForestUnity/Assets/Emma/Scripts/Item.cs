using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]

[System.Serializable]
public class Item : ScriptableObject
{
    public int id;
    public string title,
                  description;
    public Sprite icon;

    //[SerializeField]
    //private int _itemID;
    //public int ItemID
    //{
    //    get { return _itemID; }
    //    set { _itemID = value; }
    //}

    //[SerializeField]
    //private string _itemTitle;
    //public string ItemTitle
    //{
    //    get { return _itemTitle; }
    //    set { _itemTitle = value; }
    //}

    //[SerializeField]
    //private string _itemDesc;
    //public string ItemDesc
    //{
    //    get { return _itemDesc; }
    //    set { _itemDesc = value; }
    //}

    //[SerializeField]
    //private Sprite _itemIcon;
    //public Sprite ItemIcon
    //{
    //    get { return _itemIcon; }
    //    set { _itemIcon = value; }
    //}

    public Item(int id, string title, string description)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.icon = Resources.Load<Sprite>("Sprites/" + title);
    }

    public Item(Item item)
    {
        this.id = item.id;
        this.title = item.title;
        this.description = item.description;
        this.icon = Resources.Load<Sprite>("Sprites/" + item.title);
    }

}
