using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    BuildingManager buildingManager;
    public MoneySystem generator;
    public MoneySystem house;
    public MoneySystem store;

    public void Start()
    {
        buildingManager = BuildingManager.instance;
    }

    public void PurchaseGenerator()
    {
        Debug.Log("Purchased");
        buildingManager.BuildSelected(generator);
        
    }

    public void PurchaseHouse1()
    {
        Debug.Log("Purchased");
        buildingManager.BuildSelected(house);
    }

    public void PurchaseStore()
    {
        Debug.Log("Purchased");
        buildingManager.BuildSelected(store);
    }

}
