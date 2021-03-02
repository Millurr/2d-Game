using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoD
{
    public enum ItemType
    {
        Food,
        Equipment,
        Default
    }

    public abstract class ItemObject : ScriptableObject
    {
        public GameObject prefab;
        public ItemType type;

        [TextArea(15, 20)]
        public string description;
    }
}