using System.Collections;
using System.Collections.Generic;
using AudioSettings;
using CandFarmEnums;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUiManager : MonoBehaviour
{

    [Header("Player Profile")]
    [SerializeField]
    Image PlayerProfilePic;
    [SerializeField]
    TextMeshProUGUI playerNameText;
    [SerializeField]
    TextMeshProUGUI playerLevelText;
    public MenuHandler menuHandler;

    void Start()
    {
        menuHandler = MenuHandler.Instance;
        Invoke(nameof(init), (AudioManager.Instance == null) ? 5 : 0);
        UpdateUserProfileUi();
        Invoke(nameof(UpdateUserProfileUi), 2);

    }

    void init()
    {
        AudioManager.Instance.PlaySound(AudioGroup.BgMusic, AudioClipNames.BgMusic.MenuMusic.ToString(), true);
        AudioManager.Instance.PlayAmbience(true);
    }
    public void onPlayGame()
    {
        AudioManager.Instance.PlaySound(AudioGroup.Sfx, AudioClipNames.Sfx.ButtoClick.ToString());
        SceneManager.LoadScene("Game");
    }
    public void EnterProfile()
    {
        SceneManager.LoadScene(SceneNames.Userprofile.ToString());
    }

    public void EnterTutorial()
    {
        SceneManager.LoadScene(SceneNames.Tutorial.ToString());
    }
    private void UpdateUserProfileUi()
    {
        PlayerManager player = MenuHandler.Instance.GetPlayer();
        var playerData = player.PlayerData;
        print(PlayerProfilePic);
        // playerNameText.text = playerData.playerName;
        // playerLevelText.text = "Lvl " + playerData.playerLevel.ToString();

    }
}
