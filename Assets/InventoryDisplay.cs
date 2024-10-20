using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Correct namespace for Image component

public class InventoryDisplay : MonoBehaviour
{
    public List<GameObject> inventorySlots = new List<GameObject>();
    public GameObject inventoryDisplayObj;  // The parent object holding the item slots
    public GameObject weightDisplayObj;     // The weight display object to be excluded

    public List<Item> itemsInInventory;     // List of items in inventory
    public Sprite defaultItemIcon;          // Default icon for empty slots

    Inventory inventory; // inventory reference

    public void UpdateInventory()
    {
        // Clear out the inventorySlots list to prevent duplicates
        inventorySlots.Clear();

        // Loop through all child objects of the inventory display (excluding weightDisplayObj)
        for (int i = 0; i < inventoryDisplayObj.transform.childCount; i++)
        {
            GameObject child = inventoryDisplayObj.transform.GetChild(i).gameObject;

            // Get the Image component once
            Image slotImage = child.GetComponent<Image>();

            // Handle slot image assignment if it exists
            if (slotImage != null)
            {
                // Check if the item exists in the inventory at the current index
                if (i < itemsInInventory.Count)
                {
                    // Get the item preview and set it to the slot image
                    Item currentItem = itemsInInventory[i];
                    slotImage.sprite = currentItem.itemPreview;  // Assuming your item has an 'icon' field
                }
                else
                {
                    // Set the default icon if no item is available
                    slotImage.sprite = defaultItemIcon;
                }

                // Log for debugging
                Debug.Log($"Slot {i} ({child.name}) has an Image component and was updated.");
            }
            else
            {
                // Log if no Image component was found
                Debug.LogWarning($"Slot {i} ({child.name}) does not have an Image component.");
            }

            // Check if the child is not the weight display object
            if (child != weightDisplayObj)
            {
                inventorySlots.Add(child);  // Add the child item slot to the inventory
            }
        }

        Debug.Log($"Inventory updated: {inventorySlots.Count} slots.");
    }
}