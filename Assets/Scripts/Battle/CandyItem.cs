using CandFarmEnums;
using UnityEngine;
using UnityEngine.Pool;

public class CandyItem : MonoBehaviour
{
    [HideInInspector]
    public CandyType candyType;

    private IObjectPool<CandyItem> candyItemPool;

    [HideInInspector]
    public bool candyCaught = false;

    public void SetPool(IObjectPool<CandyItem> pool)
    {
        candyItemPool = pool;
    }

    public void updateCandyItem(Candy candy)
    {
        candyType = candy.candyType;
        GetComponent<SpriteRenderer>().sprite = candy.sprite;
    }


}