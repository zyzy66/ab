using NUnit.Framework;
using System.Collections.Generic;


public class LeaderboardSystemTests
{
    [Test]
    public void TestGetTopScores()
    {
        // 正常情况
        int[] scores = { 100, 50, 75, 80, 65 };
        int m = 3;
        List<int> result = LeaderboardSystem.GetTopScores(scores, m);
        List<int> expected = new List<int> { 100, 80, 75 };
        Assert.AreEqual(expected, result);

        // m 超过数组长度
        int[] scores2 = { 100, 50, 75 };
        m = 5;
        result = LeaderboardSystem.GetTopScores(scores2, m);
        expected = new List<int> { 100, 75, 50 };
        Assert.AreEqual(expected, result);

        // 空数组
        int[] scores3 = { };
        m = 3;
        result = LeaderboardSystem.GetTopScores(scores3, m);
        expected = new List<int> { };
        Assert.AreEqual(expected, result);

        // m 为 0
        int[] scores4 = { 100, 50, 75 };
        m = 0;
        result = LeaderboardSystem.GetTopScores(scores4, m);
        expected = new List<int> { };
        Assert.AreEqual(expected, result);
    }
}
