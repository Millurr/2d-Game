using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoD
{
    [CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory System/Items/Equipment")]
    public class EquipmentObject : ItemObject
    {
        public float atkBonus;
        public float defenceBonus;

        void Awake()
        {
            type = ItemType.Equipment;
        }
    }
}