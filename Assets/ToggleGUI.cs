using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGUI : MonoBehaviour
{
    [SerializeField] GameObject InventoryGUI;

    bool InventoryActive;

    private void Update()
    {
        if (!InventoryActive && Input.GetKeyDown(KeyCode.E))
        {
            InventoryGUI.SetActive(true);
            InventoryActive = true;
        }
        else if (InventoryActive && Input.GetKeyDown(KeyCode.E))
        {
            InventoryGUI.SetActive(false);
            InventoryActive = false;
        }
    }
}
