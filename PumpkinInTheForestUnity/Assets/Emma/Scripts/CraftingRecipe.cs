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

        return craftable;
    }

    public void Craft(InventoryManager inventoryManager)
    {

        if (CanCraft(inventoryManager))
        {

            foreach (ItemAmount itemAmount in Materials)
            {
                inventoryManager.Remove(itemAmount.item);
            }
            foreach (ItemAmount itemAmount in Results)
            {
                inventoryManager.Add(itemAmount.item);
            }

        }
        else
        {
            Debug.Log("Insufficient item");
        }

    }

}
