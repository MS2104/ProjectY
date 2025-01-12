using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public int maxWeight = 100;
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

    private void OnDestroy()
    {
        // Clean up any remaining ScriptableObject instances
        foreach (var item in items)
        {
            if (item != null)
            {
                Destroy(item);
            }
        }
        items.Clear();
    }

    public void AddItem(Item itemToAdd, int stackSize)
    {
        if (currentWeight + itemToAdd.itemWeight * stackSize > maxWeight)
        {
            Debug.Log("Inventory is too full to add this item!");
            return;
        }

        bool itemExists = false;
        foreach (Item item in items)
        {
            if (item.itemID == itemToAdd.itemID)
            {
                item.itemCount += stackSize;
                itemExists = true;
                break;
            }
        }

        if (!itemExists)
        {
            // Create a new instance of the item to avoid reference issues
            Item newItem = ScriptableObject.Instantiate(itemToAdd);
            newItem.itemCount = stackSize;
            items.Add(newItem);
        }

        UpdateWeight(itemToAdd.itemWeight * stackSize);
        inventoryDisplay.UpdateInventory();
        Debug.Log($"{stackSize} {itemToAdd.name} added to inventory.");

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public void RemoveItem(int itemID)
    {
        // For loop that loops through the inventory, finds the item with the matching ID, sets it's count to 0, and removes it from the list
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].itemID == itemID)
            {
                items[i].itemCount = 0;
                items.RemoveAt(i);
                break;
            }
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