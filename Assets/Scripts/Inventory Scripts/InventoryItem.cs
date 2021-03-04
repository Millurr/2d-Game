using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Inventory System/Item")]
public class InventoryItem : ScriptableObject
{
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Sprite itemSprite;
    [SerializeField] string itemName;
    [SerializeField] string itemDescription;

    public GameObject GetPrefab()
    {
        return itemPrefab;
    }

    public Sprite GetSprite()
    {
        return itemSprite;
    }

    public string GetName()
    {
        return itemName;
    }

    public string GetDescription()
    {
        return itemDescription;
    }
}
