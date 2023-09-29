using System;
using System.Collections;
using System.Collections.Generic;
using CandFarmEnums;
using Models;
using UnityEngine;

public class PlayerManager
{
    public PlayerDataSO PlayerData;

    public int stageIndex;

    public Item[] playerItems;

    public PlayerManager(Action callback)
    {
        stageIndex = 1;
        // playerItems = new Item[]{
        //     new Item{
        //         itemName=ItemType.Speed.ToString(),
        //         itemDescription="the speed item manipulates the speed of a falling candy in the game so it doesn't fall too fast",
        //         itemAmount=200f,
        //         itemType=ItemType.Speed
        //     },
        //     new Item{
        //         itemName=ItemType.Magnet.ToString(),
        //         itemDescription="the Magnet item manipulates the Magnet of a falling candy in the game so it doesn't fall too fast",
        //         itemAmount=200f,
        //         itemType=ItemType.Magnet
        //     },
        //     new Item{
        //         itemName=ItemType.booster.ToString(),
        //         itemDescription="the booster item manipulates the booster of a falling candy in the game so it doesn't fall too fast",
        //         itemAmount=200f,
        //         itemType=ItemType.booster
        //     },
        //     new Item{
        //         itemName=ItemType.HealthBackupKey.ToString(),
        //         itemDescription="the HealthBackupKey item manipulates the HealthBackupKey of a falling candy in the game so it doesn't fall too fast",
        //         itemAmount=200f,
        //         itemType=ItemType.HealthBackupKey
        //     },
        // };
        callback();
    }

}
