using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item Item;
    public bool isCollided;

    void Pickup()
    {
        InventoryManager.instance.Add(Item);
        Destroy(gameObject);
    }

    void Update()
    {

        if (isCollided && Input.GetKeyDown(KeyCode.E))
        {
            Pickup();
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag.Equals("Player") || other.gameObject.name == "Best_Pumpkin")
        {
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

}
