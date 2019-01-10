using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BuildingManager : MonoBehaviour {
    //audios
    public AudioSource placeBuildingSound;
    public AudioSource Error;

    //building status
    private MoneySystem selectedBuilding;
    public int Level = 0;
    public GameObject generator;
    public GameObject house1;
    public GameObject store;
    public GameObject node1, node2, node3, node4, node5, node6, node7, node8, node9, node10, node11, node12, node13, node14, node15, node16;

    //UI
    public Text alert;
    public Text upgrade_text;
    public GameObject menu;

    public static BuildingManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildingManager in Scene!");
            return;
        }
        instance = this;
    }

    public void PlayPlacement() {
        placeBuildingSound.Play();
    }

    public void PlayError()
    {
        Error.Play();
    }

    private MoneySystem getSelectedBuilding;

    public void Build(Ground cube)
    {
        int currentMoney = PlayerStatus.money;
        int currentPower = PlayerStatus.usedPower;

        if (selectedBuilding.prefab != generator)
        {
            if (selectedBuilding.prefab == store) {
                if (currentPower + 1 >= PlayerStatus.powerLimit)
                {
                    alert.text = "Dont have enough power to build";
                    PlayError();
                    return;
                }
            }

            if (currentPower >= PlayerStatus.powerLimit)
            {
                alert.text = "Dont have enough power to build !";
                PlayError();
                return;
            }
        }

        if (currentMoney < selectedBuilding.cost)
        {
            currentMoney = PlayerStatus.money - selectedBuilding.cost;
            if (currentMoney < selectedBuilding.cost)
            {
                alert.text = "Dont have enough money to build !";
                PlayError();
                return;
            }
        }

        if (selectedBuilding.prefab == store) {
            PlayerStatus.money += PlayerStatus.population * 10;
        }

        if (selectedBuilding.prefab != null) {
            alert.text = "Nice !";
        }


        PlayerStatus.money -= selectedBuilding.cost;
        PlayerStatus.powerLimit += selectedBuilding.powerlimit;
        PlayerStatus.usedPower += selectedBuilding.powerspend;
        PlayerStatus.population += selectedBuilding.population;

        GameObject building = (GameObject)Instantiate(selectedBuilding.prefab, cube.GetBuildPosition(), Quaternion.identity);
        cube.building = building;

        PlayPlacement();
    }

    public bool CanBuild { get { return getSelectedBuilding != null; } }

    public void BuildSelected(MoneySystem building)
    {
        selectedBuilding = building;
    }

    public void Update()
    {
        if (PlayerStatus.money < 50) {
            GameOver();
        }
    }

    public void GameOver() {
        alert.text = "Game Over !";
        menu.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        PlayerStatus.money = 600;
        PlayerStatus.powerLimit = 0;
        PlayerStatus.usedPower = 0;
        PlayerStatus.population = 0;
    }

    public void Upgrade()
    {
    
        if (Level == 1)
        {
            if (Level == 1 && PlayerStatus.population < 40)
            {
                alert.text = "You don't have enough popularation !";
            }
            else
            {
                Level = 2;
                node8.SetActive(true);
                node9.SetActive(true);
                node10.SetActive(true);
                node11.SetActive(true);
                node12.SetActive(true);
                node13.SetActive(true);
                node14.SetActive(true);
                node15.SetActive(true);
                node16.SetActive(true);
            }
        }

        if (Level == 0)
        {
            if (PlayerStatus.population < 15)
            {
                alert.text = "You don't have enough popularation !";
            }
            else
            {
                Level = 1;
                node1.SetActive(true);
                node2.SetActive(true);
                node3.SetActive(true);
                node4.SetActive(true);
                node5.SetActive(true);
                node6.SetActive(true);
                node7.SetActive(true);
            }
        }
    }

}
