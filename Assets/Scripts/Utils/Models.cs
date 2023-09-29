
using System.Collections.Generic;
using CandFarmEnums;

namespace Models
{
    public class Reward
    {
        public Item[] items;
    }

    public class Item
    {
        public string itemName;
        public string itemDescription;
        public float itemAmount;
        public ItemType itemType;
    }

    public class InGameToken
    {
        public string tokenName;
        public string tokenDescription;
        public float amount;
    }

    public class CampaignStage
    {
        public int stageIndex;
        public GameType gameType;
        public Dictionary<CandyType, int> battleCandies;
        public float timeSpan;
        public Reward reward;
        public bool iscompleted = false;
        public bool iscurrentStage = false;
        public float expBonus;

    }
}