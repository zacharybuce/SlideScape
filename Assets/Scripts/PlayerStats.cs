using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public int coins = 0;
    public bool[] skins = new bool[30];//each skin is associated with an index
    //public Level[] lvls = new Level[90];// array holding each level
    public int[,] lvls = new int[2,90];//top row is completed, bottom is best moves
    
}
/*
public class Level
{
    public int bestMoves;//lowest moves takne to complate a level
    public bool completed;//if the level has been completed

    //general constructor
    public Level()
    {
        bestMoves = 0;
        completed = false;
    }
    */

