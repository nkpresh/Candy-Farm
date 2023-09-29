using System.Collections;
using System.Collections.Generic;
using CandFarmEnums;
using Models;
using UnityEngine;

public class BattleModeBase : MonoBehaviour
{
    internal CandySpawnController spawner;
    public BattleManager battleManager;
    public CampaignStage currentStage;

    private void Awake()
    {
        spawner = FindObjectOfType<CandySpawnController>();
    }
    private void Start()
    {
        battleManager = FindFirstObjectByType<BattleManager>();
        if (battleManager.battleMode != null)
        {
            currentStage = battleManager.battleMode.currentStage;
            LoadStageData(currentStage);
        }
        UpdateGamePlay();
        spawner.OnCandyFinished += battleManager.OnGameOver;
    }
    public virtual void LoadStageData(CampaignStage stageData)
    {
        currentStage = stageData;
        spawner.LaodCandyData(stageData);
    }
    public virtual void UpdateGamePlay()
    {

    }
    public virtual void OnCandyDropped(CandyItem candyItem)
    {

    }
    public void OnGameOver()
    {
        spawner.StopSpawningCandies();
    }
}
