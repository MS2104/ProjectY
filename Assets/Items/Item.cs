using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="New Item", menuName = "Inventory/Item")]

public class Item : ScriptableObject
{
    public string itemName;
    public int itemCount;
    public int maxStackSize;
    public int itemWeight;
    public int itemID;
    public Sprite itemPreview; // Store a Sprite for the image preview
}