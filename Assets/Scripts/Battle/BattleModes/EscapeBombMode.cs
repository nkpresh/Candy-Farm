using UnityEngine;
using Models;
using Unity.VisualScripting;
using CandFarmEnums;

public class EscapeBombMode : BattleModeBase
{
    public override void OnCandyDropped(CandyItem candyItem)
    {
        if (battleManager.isGameOver) return;
        if (candyItem.candyCaught == true)
        {
            if (candyItem.candyType == CandyType.Bomb)
            {
                battleManager.LooseHealth();
            }
        }
        else
        {
            if (candyItem.candyType != CandyType.Bomb)
            {
                battleManager.LooseHealth();
            }
        }

        spawner.candyItemPool.Release(candyItem);
    }

    public override void UpdateGamePlay()
    {
        spawner.StartSpawningCandies();
    }
}