using UnityEngine;

public class CandyBottomHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.activeSelf != false)
        {
            var candyItem = collider.GetComponent<CandyItem>();
            candyItem.candyCaught = false;
            FindFirstObjectByType<BattleManager>().battleMode.OnCandyDropped(candyItem);
        }
    }
}