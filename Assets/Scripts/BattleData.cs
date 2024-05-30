using System;

[Serializable]
public class BattleData
{
    public int EnemyAmount { get; }
    public int GoldReward { get; }
    public int XpReward { get; }

    public BattleData(int enemyAmount, int goldReward, int xpReward)
    {
        EnemyAmount = enemyAmount;
        GoldReward = goldReward;
        XpReward = xpReward;
    }
}