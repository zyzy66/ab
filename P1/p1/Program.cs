using System;
using System.Collections.Generic;

public class LeaderboardSystem
{
    public static List<int> GetTopScores(int[] scores, int m)
    {
        // 边界情况处理
        if (scores == null || scores.Length == 0 || m <= 0)
        {
            return new List<int>();
        }

        // 保存前m个最大分数
        SortedSet<int> minHeap = new SortedSet<int>();

        foreach (var score in scores)
        {
            // 将分数加入最小堆
            if (minHeap.Count < m)
            {
                minHeap.Add(score);
            }
            else if (score > minHeap.Min)
            {
                // 如果当前分数比堆中最小的分数大，则替换
                minHeap.Remove(minHeap.Min);
                minHeap.Add(score);
            }
        }

        // 转换为列表，并按从高到低排序
        List<int> topScores = new List<int>(minHeap);
        topScores.Sort((a, b) => b.CompareTo(a));

        return topScores;
    }
}
//时间复杂度为 O(n log m)

class Program
{
    static void Main(string[] args)
    {
        int[] scores = { 100, 50, 75, 80, 65 };
        int m = 3;
        var topScores = LeaderboardSystem.GetTopScores(scores, m);
        Console.WriteLine("Top Scores: " + string.Join(", ", topScores));
    }
}



