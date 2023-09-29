using Models;
using UnityEngine;

public class MenuHandler
{
    public static MenuHandler Instance;

    public CampaignStage[] GetCampaignStages()
    {
        return CampaignDataManager.Instance.GetAllStages();
    }

    public CampaignStage GetCurrentStage()
    {
        CampaignStage currentStage = CampaignDataManager.Instance.GetCurrentStage();
        return currentStage;
    }
    public MenuHandler()
    {
        Instance = this;
    }

    public PlayerManager GetPlayer()
    {
        PlayerManager playerData = GameManager.Instance.player;
        return playerData;
    }

}