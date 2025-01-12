using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class ShowItemInfo : MonoBehaviour
{
    public Image itemSprite;
    public TMP_Text itemNameDisplay;
    public TMP_Text itemTypeAndRarity;

    public void DisplayItemInfo(Item item)
    {
        itemSprite.sprite = item.itemPreview;
        itemNameDisplay.text = item.itemName; // Fixed line
        itemTypeAndRarity.text = item.itemType.ToString() + " " + item.itemRarity.ToString(); // Fixed line
    }

    public void HideItemInfo()
    {
        itemSprite.sprite = null;
        itemNameDisplay.text = "";
        itemTypeAndRarity.text = "";
    }
}
