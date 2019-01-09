using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BuildingManager : MonoBehaviour {
    private MoneySystem selectedBuilding;
    public GameObject generator;
    public GameObject house1;
    public GameObject store;

    public static BuildingManager instance;

    void Awake () {
        if (instance != null)
        {
            Debug.LogError("More than one BuildingManager in Scene!");
            return;
        }
        instance = this;
    }

    private MoneySystem getSelectedBuilding;

    public void Build(Ground cube)
    {
        int currentMoney = PlayerStatus.money - selectedBuilding.cost ;

        if(currentMoney < selectedBuilding.cost)
        {
            Debug.Log("Dont have enough money to build");
            return;
        }

        PlayerStatus.money -= selectedBuilding.cost;
        PlayerStatus.powerLimit += selectedBuilding.powerlimit;
        PlayerStatus.usedPower += selectedBuilding.powerspend;
        PlayerStatus.population += selectedBuilding.population;

        GameObject building = (GameObject)Instantiate(selectedBuilding.prefab, cube.GetBuildPosition(), Quaternion.identity);
        cube.building = building;   
    }

    public bool CanBuild { get { return getSelectedBuilding != null;  } }

    public void BuildSelected(MoneySystem building)
    {
        selectedBuilding = building;
    }
}
