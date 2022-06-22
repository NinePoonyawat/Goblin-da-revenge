using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGameLogic : MonoBehaviour
{
    [SerializeField]
    private int bossToEliminated = 1;

    [SerializeField]
    private GameObject winMenu,lossMenu;

    public void bossEliminated()
    {
        bossToEliminated -= 1;
        if (bossToEliminated == 0)
        {
            gameWin();
        }
    }

    public void gameWin()
    {
        Time.timeScale = 0f;
        winMenu.SetActive(true);
    }

    public void gameLoss()
    {
        Time.timeScale = 0f;
        lossMenu.SetActive(true);
    }
}
