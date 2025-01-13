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
    }
}