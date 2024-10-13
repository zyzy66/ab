using NUnit.Framework;

public class TreasureHuntSystemTests
{
    [Test]
    public void TestMaxTreasureValue()
    {
        int[] treasures1 = { 3, 1, 5, 2, 4 };
        Assert.AreEqual(12, TreasureHuntSystem.MaxTreasureValue(treasures1));

        int[] treasures2 = { 2, 7, 9, 3, 1 };
        Assert.AreEqual(12, TreasureHuntSystem.MaxTreasureValue(treasures2));

        int[] treasures3 = { 5, 5, 10, 100, 10, 5 };
        Assert.AreEqual(110, TreasureHuntSystem.MaxTreasureValue(treasures3));

        int[] treasures4 = { 1 };
        Assert.AreEqual(1, TreasureHuntSystem.MaxTreasureValue(treasures4));

        int[] treasures5 = { 1, 2 };
        Assert.AreEqual(2, TreasureHuntSystem.MaxTreasureValue(treasures5));
    }
}
