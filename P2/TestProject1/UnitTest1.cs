using NUnit.Framework;

public class EnergyFieldSystemTests
{
    [Test]
    public void TestMaxEnergyField()
    {
        // 普通情况
        int[] heights = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
        float result = EnergyFieldSystem.MaxEnergyField(heights);
        Assert.AreEqual(52.5f, result);

        //极端情况，所有塔高度相同
        heights = new int[] { 5, 5, 5, 5, 5 };
        result = EnergyFieldSystem.MaxEnergyField(heights);
        Assert.AreEqual(20.0f, result);

        //只有一座塔
        heights = new int[] { 8 };
        result = EnergyFieldSystem.MaxEnergyField(heights);
        Assert.AreEqual(0, result);

        //两座塔
        heights = new int[] { 3, 7 };
        result = EnergyFieldSystem.MaxEnergyField(heights);
        Assert.AreEqual(5.0f, result);

        //使用魔法道具提高高度
        heights = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
        int[] magicBoost = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        result = EnergyFieldSystem.MaxEnergyField(heights, magicBoost);
        Assert.AreEqual(59.5f, result);

        //存在高度为0
        heights = new int[] { 5, 0, 3, 7, 0 };
        result = EnergyFieldSystem.MaxEnergyField(heights);
        Assert.AreEqual(18.0f, result);
    }
}
