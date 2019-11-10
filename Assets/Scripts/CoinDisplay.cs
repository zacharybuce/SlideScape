using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinDisplay : MonoBehaviour
{
    public PlayerStats playerStats;
    public TextMeshProUGUI coinsDisplay;

    private void Start()
    {
        coinsDisplay.SetText(playerStats.coins.ToString());
    }

    public void changeCoins( int amount)
    {
        playerStats.coins += amount;
        coinsDisplay.SetText(playerStats.coins.ToString());
    }

}
