using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CandFarmEnums;
using System;

[CreateAssetMenu(fileName = "", menuName = "CandyFarm/PlayerData")]
public class PlayerDataSO : ScriptableObject

{
    public string playerId;
    public string playerName;
    public int playerLevel;
    public float expLevel;
    public int pictureIndex;
    public int currentStageIndex;

}
