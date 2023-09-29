using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAnimation : MonoBehaviour
{
    public GameObject movingBg;
    Material material;

    Vector2 offset;

    public bool isMoving;

    public float xVelocity, yVelocity;
    private void Awake()
    {
        material = movingBg.GetComponent<Renderer>().material;
        isMoving = true;
    }

    private void Start()
    {
        offset = new Vector2(xVelocity, yVelocity);
    }
    private void Update()
    {
        if (isMoving)
            material.mainTextureOffset += offset * Time.deltaTime;
    }
}
