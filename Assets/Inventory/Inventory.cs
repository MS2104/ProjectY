using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public static Inventory instance;
    public List<Item> items = new List<Item>();
    public int currentWeight;
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
        if (currentWeight + itemToAdd.itemWeight > maxWeight)
        {
            Debug.Log("Inventory is too full to add this item!");
            return;
        }
        bool itemExists = false;
        foreach (Item item in items)
        {
            if (item.name == itemToAdd.name)
            {
                item.itemCount += itemToAdd.itemCount;
                itemExists = true;
                break;
            }
        }
        if (!itemExists)
        {
            items.Add(itemToAdd);
        }

        UpdateWeight(itemToAdd.itemWeight);
        inventoryDisplay.UpdateInventory();
        Debug.Log($"{itemToAdd.itemCount} {itemToAdd.name} added to inventory.");

        // Trigger the callback
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public void RemoveItem(Item itemToRemove)
    {
        Item itemToUpdate = items.Find(item => item.name == itemToRemove.name);
        if (itemToUpdate != null)
        {
            itemToUpdate.itemCount -= itemToRemove.itemCount;
            if (itemToUpdate.itemCount <= 0)
            {
                items.Remove(itemToUpdate);
            }
            UpdateWeight(-itemToRemove.itemWeight);
            inventoryDisplay.UpdateInventory();
            Debug.Log($"{itemToRemove.itemCount} {itemToRemove.name} removed from inventory.");

            // Trigger the callback
            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
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