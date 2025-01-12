using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventorySorter : MonoBehaviour
{
    Inventory inventory;

    private void Start()
    {
        inventory = Inventory.instance;
    }

    public void Dropdown(int index)
    {
        switch (index)
        {
            case 0:
                SortByName();
                break;
            case 1:
                SortByType();
                break;
            case 2:
                SortByRandom();
                break;
            case 3:
                SortByRarity();
                break;
            case 4:
                SortByStackSize();
                break;
        }
    }

    void SortByName()
    {
        inventory.items = inventory.items.OrderBy(item => item.itemName).ToList();
        inventory.inventoryDisplay.UpdateInventory();
        Debug.Log("Inventory has been sorted by name.");
    }

    void SortByType()
    {
        inventory.items = inventory.items.OrderBy(item => item.itemType).ToList();
        inventory.inventoryDisplay.UpdateInventory();
        Debug.Log("Inventory has been sorted by type.");
    }

    void SortByRandom()
    {
        System.Random random = new System.Random();
        inventory.items = inventory.items.OrderBy(item => random.Next()).ToList();
        inventory.inventoryDisplay.UpdateInventory();
        Debug.Log("Inventory has been sorted randomly.");
    }

    void SortByRarity()
    {
        inventory.items = inventory.items.OrderBy(item => item.itemRarity).ToList();
        inventory.inventoryDisplay.UpdateInventory();
        Debug.Log("Inventory has been sorted by rarity.");
    }

    void SortByStackSize()
    {
        inventory.items = inventory.items.OrderBy(item => item.itemCount).ToList();
        inventory.inventoryDisplay.UpdateInventory();
        Debug.Log("Inventory has been sorted by stack size.");
    }
}
