using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    public bool isInteracting = false;

    [SerializeField] Transform invetoryUIParent;
    // Start is called before the first frame update
    void Start()
    {
        inventory.InitInventory(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isInteracting = !isInteracting;
        }
        
        if (isInteracting)
        {
            inventory.OpenInventoryUI();
        }
        else
        {
            inventory.CloseInventoryUI();
        }
    }

    public Transform GetUIParent()
    {
        return invetoryUIParent;
    }
}
