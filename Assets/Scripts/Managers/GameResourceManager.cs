using System.Resources;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class GameResourceManager : Singleton<GameResourceManager>
{

    public void GetPlayerData(Action<PlayerDataSO> callback)
    {
        StartCoroutine(GetPlayerDataSO("ScriptableObjects/PlayerData", callback));
    }

    IEnumerator<PlayerDataSO> GetPlayerDataSO(string dir, Action<PlayerDataSO> callback)
    {

        ResourceRequest request = Resources.LoadAsync<PlayerDataSO>(dir);
        yield return request.asset as PlayerDataSO;
        callback(request.asset as PlayerDataSO);
    }




}
