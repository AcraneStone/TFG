using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class InventoryItem<T> where T : Item
{
    public T itemInventory;

    public float precio;



    public InventoryItem(T item)
    {
        itemInventory = item;
    }

}

