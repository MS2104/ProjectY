using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<Item> items = new List<Item>();
    int currentWeight;
    public int maxWeight = 100; // Set a default max weight
    public TMP_Text weightDisplay;

    public InventoryDisplay inventoryDisplay;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.Log("Duplicate Inventory instance found, destroying object.");
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);
        Debug.Log("Inventory instance initialized.");
    }

    public void AddItem(Item itemToAdd)
    {
        if (currentWeight + itemToAdd.weight > maxWeight)
        {
            Debug.Log("Inventory is too full to add this item!");
            return;
        }
        bool itemExists = false;
        foreach (Item item in items)
        {
            if (item.name == itemToAdd.name)
            {
                item.count += itemToAdd.count;
                itemExists = true;
                break;
            }
        }
        if (!itemExists)
        {
            items.Add(itemToAdd);
        }

        UpdateWeight(itemToAdd.weight);
        inventoryDisplay.UpdateInventory();
        Debug.Log($"{itemToAdd.count} {itemToAdd.name} added to inventory.");
    }

    public void RemoveItem(Item itemToRemove)
    {
        Item itemToUpdate = items.Find(item => item.name == itemToRemove.name);
        if (itemToUpdate != null)
        {
            itemToUpdate.count -= itemToRemove.count;
            if (itemToUpdate.count <= 0)
            {
                items.Remove(itemToUpdate);
            }
            UpdateWeight(-itemToRemove.weight);
            inventoryDisplay.UpdateInventory();
            Debug.Log($"{itemToRemove.count} {itemToRemove.name} removed from inventory.");
        }
        else
        {
            Debug.LogWarning($"Attempted to remove non-existent item: {itemToRemove.name}");
        }
    }

    void UpdateWeight(int weightVar)
    {
        currentWeight += weightVar;
        if (weightDisplay != null)
        {
            weightDisplay.text = "Weight: " + currentWeight;
        }
        else
        {
            Debug.LogWarning("weightDisplay is not set in the Inventory script.");
        }
    }
}