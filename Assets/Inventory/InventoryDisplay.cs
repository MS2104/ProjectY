using System.Collections.Generic;
using System.Linq;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    // List containing all gameobjects with the inventoryslot component

    public InventorySlot[] inventorySlots;  // Array of all inventory slots

    public GameObject inventoryDisplayObj;  // The parent object holding the item slots
    public GameObject weightDisplayObj;     // The weight display object to be excluded

    public Sprite defaultItemIcon;          // Default icon for empty slots

    Inventory inventory; // inventory reference

    private void Start()
    {
        inventory = Inventory.instance;
    }

    public void UpdateInventory()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                inventorySlots[i].AddItem(inventory.items[i]);
            }
            else
            {
                inventorySlots[i].ClearSlot();
            }
        }
    }
}
