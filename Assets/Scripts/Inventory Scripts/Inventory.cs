using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Inventory System/Inventory")]
public class Inventory : ScriptableObject
{

    [SerializeField] List<InventoryItemWrapper> items = new List<InventoryItemWrapper>();
    [SerializeField] InventoryUI inventoryUIPrefab;

    PlayerInventory playerInventory;

    InventoryUI _inventoryUI;
    InventoryUI inventoryUI
    {
        get
        {
            if (!_inventoryUI)
                _inventoryUI = Instantiate(inventoryUIPrefab, playerInventory.GetUIParent());
            return _inventoryUI;
        }
    }

    Dictionary<InventoryItem, int> itemToCountMap = new Dictionary<InventoryItem, int>();

    public void InitInventory(PlayerInventory playerInventory)
    {
        this.playerInventory = playerInventory;
        for (int i = 0; i < items.Count; i++)
        {
            itemToCountMap.Add(items[i].GetItem(), items[i].GetItemCount());
        }
    }

    public void OpenInventoryUI()
    {
        inventoryUI.gameObject.SetActive(true);
        inventoryUI.InitInventoryUI(this);
    }

    public void CloseInventoryUI()
    {
        inventoryUI.gameObject.SetActive(false);
    }

    public void AssignItem(InventoryItem item)
    {
        Debug.Log(string.Format("Player assigned {0} item", item.GetName()));
    }

    public Dictionary<InventoryItem, int> GetAllItemsMap()
    {
        return itemToCountMap;
    }

    public void AddItem(InventoryItem item, int count)
    {
        int currentItemCount;
        if (itemToCountMap.TryGetValue(item, out currentItemCount))
        {
            itemToCountMap[item] = currentItemCount + count;
        }
        else
        {
            itemToCountMap.Add(item, count);
        }
        inventoryUI.CreateOrUpdateSlot(this, item, count);
    }

    public void RemoveItem(InventoryItem item, int count)
    {
        int currentItemCount;
        if (itemToCountMap.TryGetValue(item, out currentItemCount))
        {
            itemToCountMap[item] = currentItemCount - count;
            if (currentItemCount - count <= 0)
            {
                inventoryUI.DestroySlot(item);
            }
            else
            {
                inventoryUI.UpdateSlot(item, currentItemCount - count);
            }
        }
        else
        {
            Debug.Log(string.Format("Can't remove {0}. This item is not in the inventory", item.GetName()));
        }
    }
}
