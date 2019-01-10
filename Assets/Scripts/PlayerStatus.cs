using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour {
    public static int money;

    //power
    public static int powerLimit;
    public static int usedPower;

    //money
    public int startMoney = 600;

    //
    public static int population;

    public Text playerMoney;
    public Text playerPower;
    public Text playerPopulation;

    void Start()
    {
        money = startMoney;
        population = 0;
    }

    private void Update()
    {
        playerMoney.text = money.ToString();
        playerPower.text = usedPower + "/" + powerLimit;
        playerPopulation.text = population.ToString();
    }
}
