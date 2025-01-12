using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour
{
    public Button removeButton; // Reference to the remove button

    [Header("Item info objects")]
    public Image icon; // Reference to the Icon image
    public Image rarityDisplay;
    public TMP_Text stackSize; // Reference to the stack size text

    public ShowItemInfo showItemInfo;

    Transform infoPanel;

    Item item;  // Current item in the slot

    // Add item to the slot
    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.itemPreview;
        stackSize.text = item.itemCount.ToString();
        stackSize.gameObject.SetActive(true); // Enable the stack size text

        icon.enabled = true;
        removeButton.interactable = true;
    }

    // Clear the slot
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        stackSize.text = "0";
        stackSize.gameObject.SetActive(false); // Disable the stack size text
        removeButton.interactable = false;
    }

    // Called when the remove button is pressed
    public void OnRemoveButtonClick()
    {
        Inventory.instance.RemoveItem(item.itemID);
        ClearSlot();
    }

    public void OnInfoButtonClick()
    {
        if (item != null)
        {
            showItemInfo.DisplayItemInfo(item);
        }
    }
}
