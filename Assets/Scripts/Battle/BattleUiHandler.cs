using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleUiHandler : MonoBehaviour
{

    [SerializeField] Slider healthProgressUi;
    [SerializeField] TextMeshProUGUI TimerUi;
    [SerializeField] Image TargetUiImage;
    [SerializeField] TextMeshProUGUI targetText;

    public static BattleUiHandler instance;
    BattleManager battleManager;

    private void Start()
    {
        instance = this;
        battleManager = FindFirstObjectByType<BattleManager>();

        if (battleManager)
        {
            init();
        }
    }

    private void init()
    {
        updateHealthProgress();
    }

    public void updateHealthProgress()
    {
        float healthPrgress = battleManager.GetInGamePlayer().currentHp / battleManager.GetInGamePlayer().maxHp;
        healthProgressUi.value = healthPrgress;
    }

    public void OpenInGameMenu()
    {

    }

    public void CloseInGameMenu()
    {

    }
}