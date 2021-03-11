using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour
{
    public int money = 100;
    Text moneyText;
    Defender moneyCost;

    private void Start()
    {
        moneyText = GetComponent<Text>();
        moneyCost = FindObjectOfType<Defender>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        moneyText.text = money.ToString();
    }

    public bool HasMoney(int amount)
    {
        return money >= amount;
    }

    public void AddMoney(int amount)
    {
        money += amount;
        UpdateDisplay();
    }

    public void SpendMoney(int amount)
    {
        if (money >= amount)
        {
            money -= amount;
            UpdateDisplay();
        }
    }
}
