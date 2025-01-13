using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="New Item", menuName = "Inventory/Item")]

public class Item : ScriptableObject
{
    public string itemName;
    public int itemCount;
    public int maxStackSize;
    public int itemWeight;

    //
    public ItemType itemType;
    public ItemRarity itemRarity;
    public Sprite itemRaritySprite;

    public int itemID;
    public Sprite itemPreview; // Store a Sprite for the image preview

    // Enumerators for item types and rarities
    public enum ItemType { Material, Weapon, Consumable, Quest };
    public enum ItemRarity { Common, Uncommon, Rare, Epic, Legendary, Mythic };
}





