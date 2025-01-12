using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Changed to TMP since inventory uses TextMeshPro

public class Pickup : MonoBehaviour
{
    public Item item;
    public int stackSize = 1;  // Default to 1
    private Inventory inventory;
    public TMP_Text weightDisplay;  // Changed to TMP_Text

    private void Start()  // Changed from Awake to Start to ensure Inventory singleton exists
    {
        inventory = Inventory.instance;
        if (inventory == null)
        {
            Debug.LogError("No Inventory instance found!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (inventory != null)
        {
            // Check if adding the item would exceed max weight
            if (inventory.currentWeight + (item.itemWeight * stackSize) <= inventory.maxWeight)
            {
                inventory.AddItem(item, stackSize);
                // Remove UpdateWeight call as it's now handled in inventory.AddItem
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Cannot pick up item - inventory would exceed weight limit!");
            }
        }
    }

    // Remove UpdateWeight method as it's now handled in the Inventory class

    private void OnValidate()
    {
        if (item != null)
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.sprite = item.itemPreview;  // Changed from itemPreview to icon to match Item class
            }
        }
    }
}