using System.Collections;
using System.Collections.Generic;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageUiItem : MonoBehaviour
{

    Color stageColor;

    [SerializeField]
    GameObject lockUi;
    [SerializeField]
    TextMeshProUGUI textUi;
    void Start()
    {

    }

    public void updateStageItem(CampaignStage stageData)
    {
        if (stageData.iscompleted == true || stageData.iscurrentStage == true)
        {
            gameObject.GetComponent<Image>().color = Color.white;
            textUi.text = stageData.stageIndex.ToString();
            EnableStageUiItems(true);
        }
        else
        {
            gameObject.GetComponent<Image>().color = Color.black;
            EnableStageUiItems(false);
        }
    }

    public void EnableStageUiItems(bool active)
    {
        lockUi.SetActive(!active);
        textUi.gameObject.SetActive(active);
    }
}
