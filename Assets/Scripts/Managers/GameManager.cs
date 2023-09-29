using System;
using System.Collections;
using System.Collections.Generic;
using CandFarmEnums;
using Models;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class GameManager : Singleton<GameManager>
{
    public ProfilePictureDataSO profilePicDataSO;

    public PlayerManager player;


    MenuHandler mainMenu;
    void Awake()
    {
        player = new PlayerManager(() =>
        {
            LoadPlayerData();
        });
        
        mainMenu = new MenuHandler();
    }

    public void LoadPlayerData()
    {

        GameResourceManager.Instance.GetPlayerData((playerData) =>
        {
            player.PlayerData = playerData;
        });

    }

    public Sprite GetProfilePicture(int Index)
    {
        return profilePicDataSO.GetImage(Index);
    }
}
