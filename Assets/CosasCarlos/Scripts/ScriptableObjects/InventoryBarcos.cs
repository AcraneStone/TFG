using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventario Barcos", menuName = "ScriptableObjects/Inventarios/Barcos")]

public class InventoryBarcos : Inventory<SerialBarco, Barcos>
{
    public override void Add(Barcos item)
    {
        SerialBarco newBarco = new(item);
        inventoryList.Add(newBarco);
        

    }

    public override void Add(Barcos item, int quantity)
    {
        throw new System.NotImplementedException();
    }

    public override void Remove(Barcos item)
    {
        throw new System.NotImplementedException();
    }

    public override void Remove(Barcos item, int quantity)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
