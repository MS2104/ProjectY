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
            inventory.AddItem(item, stackSize);
            // Remove UpdateWeight call as it's now handled in inventory.AddItem
            Destroy(gameObject);
        }
    }

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