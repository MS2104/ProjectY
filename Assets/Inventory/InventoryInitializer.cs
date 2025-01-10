using UnityEngine;

public class InventoryInitializer : MonoBehaviour
{
    public static InventoryInitializer instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        InitializeInventory();
    }

    void InitializeInventory()
    {
        if (Inventory.instance == null)
        {
            Debug.Log("Inventory instance not found. Creating new Inventory.");
            GameObject inventoryObject = new GameObject("Inventory");
            inventoryObject.AddComponent<Inventory>();
            DontDestroyOnLoad(inventoryObject);
        }
        else
        {
            Debug.Log("Existing Inventory instance found.");
        }
    }

    public static Inventory GetInventory()
    {
        if (Inventory.instance == null)
        {
            Debug.LogWarning("Inventory instance is null. Attempting to create a new one.");
            instance.InitializeInventory();
        }

        return Inventory.instance;
    }
}