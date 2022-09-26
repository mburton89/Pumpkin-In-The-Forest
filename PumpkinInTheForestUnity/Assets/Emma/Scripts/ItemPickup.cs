using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item Item;

    void Pickup()
    {
        InventoryManager.instance.Add(Item);
        Destroy(gameObject);
    }

    void Update()
    {

        if (Item.isCollided)
        {
            Debug.Log("Collision");
        }

        if (Item.isCollided && Input.GetKeyDown(KeyCode.E))
        {
            Pickup();
        }

    }

}
