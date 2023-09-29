using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CandFarmEnums;
using System;

[CreateAssetMenu(fileName = "", menuName = "CandyFarm/Target")]

public class TargetSO : ScriptableObject
{
    [SerializeField]
    Target[] targets;


    public Target GetTarget(int index)
    {
        return targets[index];
    }

    public Target GetRandomTarget()
    {
        int randonIndex = UnityEngine.Random.Range(0, targets.Length);
        return GetTarget(randonIndex);
    }
}

[Serializable]
public class Target
{
    public CandyType cadnyType;
    public int amount;

    public void updateData(Target target)
    {
        cadnyType = target.cadnyType;
        amount = target.amount;
    }

    public bool updateTarget()
    {
        amount--;
        return (amount == 0);
    }
}
