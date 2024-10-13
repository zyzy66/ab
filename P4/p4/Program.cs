using System;

public class TalentAssessmentSystem
{
    public static double FindMedianTalentIndex(int[] fireAbility, int[] iceAbility)
    {
        // 确保 fireAbility 是较短的数组，减少二分查找的次数
        if (fireAbility.Length > iceAbility.Length)
        {
            return FindMedianTalentIndex(iceAbility, fireAbility);
        }

        int n = fireAbility.Length;
        int m = iceAbility.Length;
        int totalLength = n + m;
        int halfLength = (totalLength + 1) / 2;

        int left = 0, right = n;

        while (left <= right)
        {
            int partitionFire = (left + right) / 2;
            int partitionIce = halfLength - partitionFire;

            // 边界处理
            int maxLeftFire = (partitionFire == 0) ? int.MinValue : fireAbility[partitionFire - 1];
            int minRightFire = (partitionFire == n) ? int.MaxValue : fireAbility[partitionFire];

            int maxLeftIce = (partitionIce == 0) ? int.MinValue : iceAbility[partitionIce - 1];
            int minRightIce = (partitionIce == m) ? int.MaxValue : iceAbility[partitionIce];

            // 符合条件，找到中位数
            if (maxLeftFire <= minRightIce && maxLeftIce <= minRightFire)
            {
                // 总长度是奇数，中位数是左侧最大值
                if (totalLength % 2 == 1)
                {
                    return Math.Max(maxLeftFire, maxLeftIce);
                }
                // 总长度是偶数，中位数是左边最大值和右边最小值的平均值
                else
                {
                    return (Math.Max(maxLeftFire, maxLeftIce) + Math.Min(minRightFire, minRightIce)) / 2.0;
                }
            }
            // 调整分割点
            else if (maxLeftFire > minRightIce)
            {
                right = partitionFire - 1;
            }
            else
            {
                left = partitionFire + 1;
            }
        }

        throw new ArgumentException("输入的数组不合法");
    }
}
//使用的是二分查找，时间复杂度为 O(log(min(n, m)))，n 和 m 是两个数组的长度。
//空间复杂度是 O(1)，只使用了常数级的额外空间。

class Program
{
    static void Main(string[] args)
    {
        int[] fireAbility = { 1, 3, 7, 9, 11 };
        int[] iceAbility = { 2, 4, 8, 10, 12, 14 };

        double MedianTalent = TalentAssessmentSystem.FindMedianTalentIndex(fireAbility, iceAbility);
        Console.WriteLine("MedianTalent: " + MedianTalent);
    }
}


//天赋指数可以决定角色在游戏中的发展方向。例如，火系天赋越高的角色在学习、升级火系魔法时所需要的经验或技能点数越少。甚至有些技能需要天赋达到一定高度才能学习。
//火系魔法长于攻击、爆发，而冰系魔法长于控制、防守。还可以有其他系风系、雷系、土系。玩家可以多修，通过不同系的魔法搭配打出出乎意料的效果。
//玩家开局检测天赋，自己选择或是系统分配院系。每个院系都有自己的任务系统和技能树。玩家通过完成任务获得经验、称号，前往级别更高的魔法学院或是学院内的流派，
//或是成为某位大魔法师的弟子，学习强大稀有的魔法。一些极其困难的任务还可以给与提高天赋的奖励。
//引入属性克制，水克火，火克草，草克水。玩家在竞技场通过查看对方的天赋选择自己克制的对手，从而轻松取胜。或是反过来，放弃自己天赋最高的，通过不同系的技能配合打一个出其不意。