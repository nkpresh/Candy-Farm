using UnityEngine;
using Models;
using Unity.VisualScripting;
using CandFarmEnums;

public class EscapeBombMode : BattleModeBase
{
    public void IntializeBattleData(CampaignStage stageData)
    {

    }


    public override void OnCandyDropped(CandyItem candyItem)
    {
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
        
    }

    private void spawnCandy()
    {
        spawner.SpawnCandy();
    }
}