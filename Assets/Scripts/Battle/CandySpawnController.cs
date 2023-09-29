using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CandFarmEnums;
using Models;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class CandySpawnController : MonoBehaviour
{

    [SerializeField]
    GameObject candyPrefab;

    [SerializeField]
    CandySO[] candySOs;
    CampaignStage StageData;
    public IObjectPool<CandyItem> candyItemPool;
    private void Awake()
    {
        candyItemPool = new ObjectPool<CandyItem>(CreateCandy, OnGet, OnRelease, OnDestroyCandy, maxSize: 10);


    }

    private CandyItem CreateCandy()
    {
        var gameCandies = StageData.battleCandies;
        if (gameCandies.Count <= 0) return null;
        CandyItem newCandy = Instantiate(candyPrefab).GetComponent<CandyItem>();
        newCandy.SetPool(candyItemPool);
        return newCandy;
    }

    private void OnGet(CandyItem candyItem)
    {
        var gameCandies = StageData.battleCandies;
        candyItem.gameObject.SetActive(true);
        float randPosX = Random.Range(-GetHorizontalBounds() * 0.5f, GetHorizontalBounds() * 0.5f);
        Vector3 pos = new Vector3(randPosX, transform.position.y);
        candyItem.transform.position = pos;
        int randCandyIndex = Random.Range(0, gameCandies.Count);
        var candyElement = gameCandies.ElementAt(randCandyIndex);
        CandySO so = candySOs.FirstOrDefault((x) => x.candyType == candyElement.Key);
        candyItem.candyCaught = false;
        gameCandies[candyElement.Key] -= 1;
        if (candyElement.Value <= 0)
        {
            gameCandies.Remove(candyElement.Key);
        }
        candyItem.updateCandyItem(new Candy()
        {
            candyType = so.candyType,
            sprite = so.candyImage
        });
        if (gameCandies.Count <= 0)
        {
            CancelInvoke();
        }

    }

    private void OnRelease(CandyItem candyItem)
    {
        candyItem.gameObject.SetActive(false);
    }

    private void OnDestroyCandy(CandyItem candyItem)
    {
        Destroy(candyItem.gameObject);
    }
    public float GetHorizontalBounds()
    {
        float hSize = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        return hSize;
    }

    internal void updateGameData(CampaignStage stageData)
    {
        this.StageData = stageData;
    }

    public void SpawnCandy()
    {
        candyItemPool.Get();
    }

    void StartSpawningCandies()
    {
        
    }

    void StopSpawningCandies()
    {

    }

    void SpeedupCandySpawning(){
        
    }
}
