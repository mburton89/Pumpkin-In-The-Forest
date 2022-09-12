using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Item item;
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag.Equals("Player"))
        {
            Debug.Log("COLLISION");
            item.isCollided = true;
        }

        if (other.gameObject.name == "Pumpkin")
        {
            Debug.Log("COLLISION");
            item.isCollided = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.name.Equals("Pumpkin"))
        {
            Debug.Log("NO COLLISION");
            item.isCollided = false;
        }

    }
}
