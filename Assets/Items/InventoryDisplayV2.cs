using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplayV2 : MonoBehaviour
{
    Inventory inventory;

    [SerializeField] GameObject inventoryDisplayObj;
    [SerializeField] GameObject weightDisplayObj;

    [SerializeField] List<GameObject> inventorySlotObjs = new List<GameObject>();

    void UpdateInventory()
    {
        for (int i = 0; i < inventoryDisplayObj.transform.childCount; i++)
        {
            GameObject child = inventoryDisplayObj.transform.GetChild(i).gameObject;

            Image slotImage = child.GetComponent<Image>();

            if (slotImage != null)
            {
                slotImage.sprite = inventory.items[i].preview;
            }
        }
    }
}
