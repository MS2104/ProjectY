using UnityEngine;

/* This object updates the inventory UI. */

public class InventoryUI : MonoBehaviour
{

	public Transform itemsParent;   // The parent object of all the items
	public GameObject inventoryUI;  // The entire UI

	Inventory inventory;    // Our current inventory

	InventorySlot[] slots;  // List of all the slots

	void Start()
	{
		inventory = Inventory.instance;
		inventory.onItemChangedCallback += UpdateUI;    // Subscribe to the onItemChanged callback

		// Populate our slots array
		slots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}

	void Update()
	{
		// Check to see if we should open/close the inventory
		if (Input.GetKeyDown(KeyCode.E))
		{
			inventoryUI.SetActive(!inventoryUI.activeSelf);
		}
	}

	// Update the inventory UI by:
	//		- Adding items
	//		- Clearing empty slots
	// This is called using a delegate on the Inventory.
	void UpdateUI()
	{

        // for loop through all the slots
        for (int i = 0; i < slots.Length; i++)
        {
            // If there is an item to add
            if (i < inventory.items.Count)
            {
                // slots[i].AddItem(inventory.items[i]);    // Add the item
                // Call the AddItem method of the InventorySlot class and pass the item contained in the inventory.items list at index i
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();   // Clear the slot
            }
        }
    }
}