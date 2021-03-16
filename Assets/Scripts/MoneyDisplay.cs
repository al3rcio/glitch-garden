using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour
{
    public float moneyBase = 1000f;
    float money;
    Text moneyText;
 

    private void Start()
    {
        money = Mathf.Round(moneyBase / (PlayerPrefsController.GetDifficulty() + 1));
        moneyText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        moneyText.text = "$ " + money.ToString();
    }

    public bool HasMoney(float amount)
    {
        return money >= amount;
    }

    public void AddMoney(float amount)
    {
        money += amount;
        UpdateDisplay();
    }

    public void SpendMoney(float amount)
    {
        if (money >= amount)
        {
            money -= amount;
            UpdateDisplay();
        }
    }
}
