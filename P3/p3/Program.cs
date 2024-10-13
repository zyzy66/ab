using System;

public class TreasureHuntSystem
{
    public static int MaxTreasureValue(int[] treasures)
    {
        if (treasures == null || treasures.Length == 0)
            return 0;
        if (treasures.Length == 1)
            return treasures[0];

        int n = treasures.Length;
        // 记录 dp[i+1] 和 dp[i+2]
        int dp_i_1 = 0, dp_i_2 = 0;
        // 记录 dp[i]
        int dp_i = 0;

        for (int i = n - 1; i >= 0; i--)
        {
            dp_i = Math.Max(dp_i_1, treasures[i] + dp_i_2);
            dp_i_2 = dp_i_1;
            dp_i_1 = dp_i;
        }

        return dp_i;
    }
}
//时间复杂度O(n) 因为我们只遍历了一次数组。空间复杂度O(1) 只用了常数级别的额外空间。

class Program
{
    static void Main(string[] args)
    {
        int[] treasures = { 3, 1, 5, 2, 4 };
        var maxValue = TreasureHuntSystem.MaxTreasureValue(treasures);
        Console.WriteLine("MaxTreasureValue: " + maxValue);
    }
}

//玩家在游戏中必须谨慎选择打开哪些宝箱，尤其是在面对高价值宝箱时。某些高价值的宝箱可能会被负值宝箱所围绕，玩家需要思考回报是否大于风险。
//玩家需要认真考虑何时使用魔法钥匙。如果过早使用魔法钥匙，可能会错过后续更有价值的机会，而延迟使用则可能面临较大的损失风险。
//如果魔法钥匙可以保存到后续关卡，玩家需要合理管理，为了更难的后续关卡而保存。可以在复杂的关卡中，给予额外的“魔法钥匙”作为奖励。
//提供一系列关卡，越往后要通关需要的分数越多。每个关卡提供几条可到达终点的主路，在主路上又分出许多支路，让玩家需要不断考虑各条路的风险与收益。
//支路上放置一些道具，如可以开连续两个宝箱、当前分数翻倍或是选择一个后续开的宝箱翻倍、获得无敌状态使陷阱无效、全部宝箱分数增加等等。
//还可以在路上放一些奖励次元，玩家抵达、满足分数条件就能够进入,里面没有陷阱，全是大额宝箱。
