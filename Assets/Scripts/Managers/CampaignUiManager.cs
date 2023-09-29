using System.Collections.Generic;
using System.Linq;
using Models;
using UnityEngine;
using UnityEngine.UI;

public class CampaignUiManager : MonoBehaviour
{
    [SerializeField] Transform campaignStagesUi;
    [SerializeField] Transform spotLight;

    private void Start()
    {
        updateCampaignUi();
    }


    public void updateCampaignUi()
    {
        List<CampaignStage> campaignStages = CampaignDataManager.Instance.GetAllStages().ToList();
        for (int i = 0; i < campaignStages.Count; i++)
        {
            campaignStagesUi.GetChild(i).GetComponent<StageUiItem>().updateStageItem(campaignStages[i]);
        }
    }

}