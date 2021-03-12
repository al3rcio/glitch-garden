using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostDisplay : MonoBehaviour
{
    [SerializeField] Defender defenderCost;
    CostDisplay costDisplay;
    Text textCost;
    int cost;

    private void Start()
    {
        DisplayCost();
    }

    private void DisplayCost()
    {
        cost = defenderCost.GetCost();
        costDisplay = GetComponent<CostDisplay>();
        textCost = costDisplay.GetComponentInChildren<Text>();
        textCost.text = cost.ToString();
    }
}
