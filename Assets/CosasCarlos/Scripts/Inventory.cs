using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[Serializable]
public abstract class Inventory<SerialType, ItemType> : ScriptableObject where SerialType : InventoryItem<ItemType> where ItemType : Item
{
    public currencySO currency;
    //protected InventorySO<SerialType, ItemType> inventory;
    //[SerializeField]
    public List<SerialType> inventoryList; /*= new List<SerialType>();*/ //por redundancia de tipos, ya que C# lo permite, se puede poner new(); ya que tanto a la izq como a der tenemos List<T>

    //public Dictionary<I, T> map = new Dictionary<I, T>();

    public abstract void Add(ItemType item);
    public abstract void Add(ItemType item, int quantity);


    //    if(itemDictionary.TryGetValue(item, out InventoryItem inventoryItem))
    //    {
    //            inventoryItem.AddToStack();
    //    }
    //    else
    //{
    //    InventoryItem newItem = new InventoryItem(item);
    //    inventory.Add(newItem);
    //    itemDictionary.Add(item, newItem);
    //}



    public abstract void Remove(ItemType item);

    public abstract void Remove(ItemType item, int quantity);

    //{
    //    if (itemDictionary.TryGetValue(item, out InventoryItem inventoryItem))
    //    {
    //        inventoryItem.RemoveFromStack();
    //        if(inventoryItem.stackSize == 0)
    //        {
    //            inventory.Remove(inventoryItem);
    //            itemDictionary.Remove(item);
    //        }
    //    }
    //}

    public SerialType findItem(ItemType item)
    {
        SerialType found = null;
        if (inventoryList != null)
        {
            foreach (SerialType serial in inventoryList)
            {
                if (serial.itemInventory == item)
                {
                    found = serial;
                    break;
                }
            }
        }
        return found;
    }
}
