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

    private void OnMouseDown()
    {

            Pickup();
        

    }

}
