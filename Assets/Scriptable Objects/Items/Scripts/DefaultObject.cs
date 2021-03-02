﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TwoD
{
    [CreateAssetMenu(fileName="New Default Object", menuName = "Inventory System/Items/Default")]
    public class DefaultObject : ItemObject
    {
        public void Awake()
        {
            type = ItemType.Default;
        }
    }
}