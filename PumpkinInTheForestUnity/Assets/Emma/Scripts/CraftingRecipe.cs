using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ItemAmount
{
    public Item item;
    public int amount;
}

[CreateAssetMenu]
public class CraftingRecipe : ScriptableObject
{
    public List<ItemAmount> Materials;
    public List<ItemAmount> Results;

    public bool CanCraft(InventoryManager inventoryManager)
    {
        bool craftable = true;

        foreach (ItemAmount itemAmount in Materials)
        {
            if (inventoryManager.itemCount(itemAmount.item) < itemAmount.amount)
            {
                craftable = false;
            }
            
        }

        Debug.Log("trying to check craft");

        return craftable;
    }

    public void Craft(InventoryManager inventoryManager)
    {
        Debug.Log("Entered craft");
        if (CanCraft(inventoryManager))
        {

            foreach (ItemAmount itemAmount in Materials)
            {
                for (int i = itemAmount.amount; i > 0; i--)
                {
                    inventoryManager.Remove(itemAmount.item);
                }

            }
            foreach (ItemAmount itemAmount in Results)
            {
                inventoryManager.Add(itemAmount.item);
            }
            Debug.Log("Successfully crafted");

        }
        else
        {
            Debug.Log("Insufficient item");
        }

    }

}
