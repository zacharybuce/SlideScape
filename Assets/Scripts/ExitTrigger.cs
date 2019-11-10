using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExitTrigger : MonoBehaviour
{
    public GameObject completeOverlay;
    public GameObject gameOverlay;
    public GameObject star1, star2, star3;
    public TextMeshProUGUI movesText;
    public TextMeshProUGUI coinsText;

    public PlayerStats playerStats;
    public int lvlNum = 0;

    public int oneStar;
    public int twoStar;
    public int threeStar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(FindObjectOfType<CubeMoveSwipe>().moves< playerStats.lvls[1, lvlNum]|| playerStats.lvls[1, lvlNum]==0)
            playerStats.lvls[1,lvlNum]= FindObjectOfType<CubeMoveSwipe>().moves;

            playerStats.lvls[0, lvlNum] = 1;

            movesText.SetText(playerStats.lvls[1, lvlNum].ToString());

            Invoke("setActive", 0.65f);

        }
        
    }

    private void setActive()
    {
        completeOverlay.SetActive(true);
        gameOverlay.SetActive(false);

        if (FindObjectOfType<CubeMoveSwipe>().moves <= threeStar)
        {

            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
            playerStats.coins += 5;
            coinsText.SetText("5");
        } else if (FindObjectOfType<CubeMoveSwipe>().moves <= twoStar)
            { 
            star1.SetActive(true);
            star2.SetActive(true);
            playerStats.coins += 2;
            coinsText.SetText("2");
        } else if(FindObjectOfType<CubeMoveSwipe>().moves <= oneStar)
                { star1.SetActive(true);
                  playerStats.coins += 1;
                  coinsText.SetText("1");
                }


    }
}

