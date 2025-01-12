using UnityEngine;
using TMPro;

public class DropdownHandler : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public InventorySorter inventorySorter;

    void Start()
    {
        if (dropdown != null)
        {
            dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        }
    }

    void OnDropdownValueChanged(int value)
    {
        string selectedOption = dropdown.options[value].text;

        // Grab the text of the selected option and pass it to the OnDropdownValueChanged method in the InventorySorter

        // Call the OnDropdownValueChanged method in the InventorySort and pass the selected option as a parameter

    }
}