using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketHandler : MonoBehaviour
{


    void Start()
    {

    }

    void Update()
    {
        // if (Input.touchCount >= 1)
        //     print(Input.touchCount);
        if (Camera.main.ScreenToViewportPoint(Input.mousePosition) != null)
        {
            Vector3 mouseInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float xPos = Mathf.Clamp(mouseInput.x, Bounds().x, Bounds().y);
            transform.position = new Vector3(xPos, transform.position.y, 0);
        }
    }

    Vector3 Bounds()
    {

        Camera cam = Camera.main;
        float width = cam.orthographicSize * cam.aspect;
        float objWidth = gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        return new Vector3(-width + objWidth, width - objWidth, 0);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        var candyItem = collider.GetComponent<CandyItem>();
        candyItem.candyCaught = true;
        FindFirstObjectByType<BattleManager>().battleMode.OnCandyDropped(candyItem);
    }
}
