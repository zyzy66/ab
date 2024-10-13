using NUnit.Framework;

public class EnergyFieldSystemTests
{
    [Test]
    public void TestMaxEnergyField()
    {
        // ��ͨ���
        int[] heights = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
        float result = EnergyFieldSystem.MaxEnergyField(heights);
        Assert.AreEqual(52.5f, result);

        //����������������߶���ͬ
        heights = new int[] { 5, 5, 5, 5, 5 };
        result = EnergyFieldSystem.MaxEnergyField(heights);
        Assert.AreEqual(20.0f, result);

        //ֻ��һ����
        heights = new int[] { 8 };
        result = EnergyFieldSystem.MaxEnergyField(heights);
        Assert.AreEqual(0, result);

        //������
        heights = new int[] { 3, 7 };
        result = EnergyFieldSystem.MaxEnergyField(heights);
        Assert.AreEqual(5.0f, result);

        //ʹ��ħ��������߸߶�
        heights = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
        int[] magicBoost = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        result = EnergyFieldSystem.MaxEnergyField(heights, magicBoost);
        Assert.AreEqual(59.5f, result);

        //���ڸ߶�Ϊ0
        heights = new int[] { 5, 0, 3, 7, 0 };
        result = EnergyFieldSystem.MaxEnergyField(heights);
        Assert.AreEqual(18.0f, result);
    }
}
