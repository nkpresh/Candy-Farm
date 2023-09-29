using System.Collections;
using System.Collections.Generic;
using CandFarmEnums;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "CandyFarm/Candy")]
public class CandySO : ScriptableObject
{
    public CandyType candyType;

    public Sprite candyImage;

}
