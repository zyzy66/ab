using System;

public class EnergyFieldSystem
{
    public static float MaxEnergyField(int[] heights, int[] magicBoost = null)
    {
        // 边界情况处理
        if (heights == null || heights.Length < 2)
        {
            return 0;
        }

        int left = 0;
        int right = heights.Length - 1;
        float maxArea = 0;

        // 如果有魔法道具调整塔的高度
        if (magicBoost != null && magicBoost.Length == heights.Length)
        {
            for (int i = 0; i < heights.Length; i++)
            {
                heights[i] += magicBoost[i];
            }
        }

        while (left < right)
        {
            // 塔的高度为0，跳过
            if (heights[left] == 0)
            {
                left++;
                continue;
            }

            if (heights[right] == 0)
            {
                right--;
                continue;
            }

            // 计算梯形的面积
            int h1 = heights[left];
            int h2 = heights[right];
            int distance = right - left;
            float area = (h1 + h2) * distance / 2.0f;

            // 更新最大面积
            if (area > maxArea)
            {
                maxArea = area;
            }

            // 移动较小的一侧，以便找到可能更大的面积
            if (h1 < h2)
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return maxArea;
    }
}
//遍历一次数组并调整高度需要 O(n)。双指针从两端向中间靠拢遍历一次数组，也需要 O(n)。时间复杂度为 O(n)。
//只使用了少量的局部变量，没有额外分配新的空间，空间复杂度是 O(1)

class Program
{
    static void Main(string[] args)
    {
        int[] heights = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
        int[] magicBoost = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        var maxArea = EnergyFieldSystem.MaxEnergyField(heights);
        var magicmaxArea = EnergyFieldSystem.MaxEnergyField(heights, magicBoost);
        Console.WriteLine("MaxEnergyField: " + maxArea);
        Console.WriteLine("MagicMaxEnergyField: " + magicmaxArea);
    }
}
//创意思考
//玩家不仅要考虑塔的高度，还需要注意塔与塔之间的距离。塔的高度和塔之间的距离会同时影响能量场强度，并不是最远或者最高就是最好，玩家需要不断尝试去找到最佳搭配。
//可以在地图上设计不同的道路，有的道路会有公共路口，怪物从各个刷怪点出发前往道路的终点。在道路之外分布塔的建造点，玩家可以在任意两个建造点建造塔形成能量场。
//敌人经过能量场会受到与能量场强度相关的伤害。开局告诉玩家每个刷怪点的怪物类型，顺序。各个玩家开局拥有一定数量的各种不同高度的能量塔，玩家需要把这些塔建造在建造点，
//形成能量场消灭怪物，防止怪物通过终点。击败怪物会掉落魔法道具，玩家可以用来强化防线。