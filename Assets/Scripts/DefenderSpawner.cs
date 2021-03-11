using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    MoneyDisplay moneyDisplay;

    private void Start()
    {
        moneyDisplay = FindObjectOfType<MoneyDisplay>();
    }
    public void SetDefender(Defender defenderSelected)
    {
        defender = defenderSelected;
    }
    private void OnMouseDown()
    {
        AttemptToPlace();
    }

    private void AttemptToPlace()
    {
        int cost = defender.GetCost();
        if (moneyDisplay.HasMoney(cost))
        {
            SpawnDefender(SnapToGrid(GetSquaredPos()));
            moneyDisplay.SpendMoney(cost);
        }
    }

    private Vector2 GetSquaredPos()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        
        return worldPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);

        Vector2 worldPos = new Vector2(newX, newY);
        return worldPos;
    }

    private void SpawnDefender(Vector2 worldPos)
    {
        Defender newDefender = Instantiate(defender, worldPos, transform.rotation) as Defender;
    }
}
