using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public Item item;
    Inventory inventory;
    public Text weightDisplay;

    private void Awake()
    {
        inventory = Inventory.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Inventory.instance.Add(item);
        UpdateWeight(item.itemWeight);
        Destroy(gameObject);
    }

    void UpdateWeight(int weightVar)
    {
        inventory.weight += weightVar;
        weightDisplay.text = $"Weight: {inventory.weight} kgs";
    }
}