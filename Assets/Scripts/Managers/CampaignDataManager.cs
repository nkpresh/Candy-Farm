using System.Collections.Generic;
using System.Linq;
using CandFarmEnums;
using Models;
using UnityEngine;

public class CampaignDataManager : Singleton<CampaignDataManager>
{
    CampaignData campaignData;

    private void Awake()
    {
        // LoadCampaignData();
        init();
    }

    void init()
    {
        campaignData = new CampaignData();
    }
    public CampaignStage GetCurrentStage() => campaignData.campaignStages.FirstOrDefault(x => x.iscurrentStage == true);


    public CampaignStage[] GetAllStages() => (campaignData.campaignStages.Length > 0) ? campaignData.campaignStages : null;

    public bool CheckStageCompletion(int index) => campaignData.campaignStages.FirstOrDefault(x => x.stageIndex == index).iscompleted;

    public void CompleteStage(int index)
    {
        var currentStage = GetCurrentStage();
        if (currentStage != null)
        {
            if (!CheckStageCompletion(index))
                currentStage.iscompleted = true;
        }
    }

}