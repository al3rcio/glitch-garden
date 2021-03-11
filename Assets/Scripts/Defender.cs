using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    int cost = 30;
    MoneyDisplay moneyDisplay;

    private void Start()
    {
        moneyDisplay = FindObjectOfType<MoneyDisplay>();
    }

    public int GetCost() { return cost; }

    public void AddMoney(int amount)
    {
        moneyDisplay.AddMoney(amount);
    }
}
