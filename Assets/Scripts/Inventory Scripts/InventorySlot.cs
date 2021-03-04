using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] Image itemImage;
    [SerializeField] Text itemNameText;
    [SerializeField] Text itemCountText;
    [SerializeField] Button slotButton;

    public void InitSlotVisualisation(Sprite itemSprite, string itemName, int itemCount)
    {
        itemImage.sprite = itemSprite;
        itemNameText.text = itemName;
        UpdateSlotCount(itemCount);
    }

    public void UpdateSlotCount(int itemCount)
    {
        itemCountText.text = itemCount.ToString();
    }

    public void AssignSlotButtonCallback(System.Action onClickCallback)
    {
        Debug.Log("Item clicked.");
        slotButton.onClick.AddListener(() => onClickCallback());
    }
}
