using System;
using System.Linq;
using Models;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class CandySpawnController : MonoBehaviour
{

    [SerializeField]
    GameObject candyPrefab;

    [SerializeField]
    CandySO[] candySOs;

    private float spawnTimer = 0;
    private float gravity = 1;
    CampaignStage StageData;

    public bool isGameOver = false;
    public IObjectPool<CandyItem> candyItemPool;

    public event Action OnCandyFinished;
    private void Awake()
    {
        candyItemPool = new ObjectPool<CandyItem>(CreateCandy, OnGet, OnRelease, OnDestroyCandy, maxSize: 10);
        StartCandyTimer();
    }

    private CandyItem CreateCandy()
    {
        var gameCandies = StageData.battleCandies;
        if (gameCandies.Count <= 0) return null;
        CandyItem newCandy = Instantiate(candyPrefab).GetComponent<CandyItem>();
        newCandy.SetPool(candyItemPool);
        return newCandy;
    }

    void StartCandyTimer()
    {
        InvokeRepeating(nameof(Count), 0, 1);
    }

    void Count()
    {
        if (isGameOver)
        {
            CancelInvoke("Count");
        }
        spawnTimer++;
        if (spawnTimer == 7)
        {
            IncreaseGravity();
            spawnTimer = 0;
        }
    }

    void IncreaseGravity()
    {
        if (gravity >= 7) return;
        gravity += 1;
        print(gravity);

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
        candyItem.GetComponent<Rigidbody2D>().gravityScale = gravity;
        if (gameCandies.Count <= 0)
        {
            if (OnCandyFinished != null)
                OnCandyFinished();
        }

    }

    private void OnRelease(CandyItem candyItem)
    {
        candyItem.gameObject.SetActive(false);
    }

    public void OnDestroyCandy(CandyItem candyItem)
    {
        Destroy(candyItem.gameObject);
    }
    private float GetHorizontalBounds()
    {
        float hSize = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        return hSize;
    }

    internal void LaodCandyData(CampaignStage stageData)
    {
        this.StageData = stageData;
    }

    private void SpawnCandy()
    {
        candyItemPool.Get();
    }

    public void StartSpawningCandies()
    {
        InvokeRepeating(nameof(SpawnCandy), 1, 1);
    }

    public void StopSpawningCandies()
    {
        isGameOver = true;
        CancelInvoke(nameof(SpawnCandy));
        var candyItems = FindObjectsByType<CandyItem>(FindObjectsSortMode.None);
        foreach (CandyItem item in candyItems)
        {
            item.gameObject.SetActive(false);
        }
    }
}
