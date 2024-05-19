using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/Player")]
public class PlayerSO : ScriptableObject
{
    public currencySO playerCurrency;
    public InventoryProductSO playerInventory;
    public InventoryServiceSO inventoryService;
    //private List<Barcos> flota;
}
