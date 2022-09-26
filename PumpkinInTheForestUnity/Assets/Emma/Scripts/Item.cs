using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public int id;
    public string title,
                  description;
    public Sprite icon;
    public bool isCollided;


    public Item(int id, string title, string description)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.icon = Resources.Load<Sprite>("Sprites/" + title);
        this.isCollided = false;
    }

    public Item(Item item)
    {
        this.id = item.id;
        this.title = item.title;
        this.description = item.description;
        this.icon = Resources.Load<Sprite>("Sprites/" + item.title);
        this.isCollided = false;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag.Equals("Player") || other.gameObject.name == "Best_Pumpkin")
        {
            Debug.Log("Collision");
            isCollided = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag.Equals("Player") || other.gameObject.name == "Best_Pumpkin")
        {
            isCollided = false;
        }

    }

    //private void OnCollisionEnter(Collision collision)
    //{

    //    if (collision.gameObject.name == "Pumpkin")
    //    {
    //        Debug.Log("COLLISION");
    //        isCollided = true;
    //    }

    //}

    //private void OnCollisionExit(Collision collision)
    //{

    //    if (collision.gameObject.name == "Pumpkin")
    //    {
    //        Debug.Log("NO COLLISION");
    //        isCollided = false;
    //    }

    //}

}
