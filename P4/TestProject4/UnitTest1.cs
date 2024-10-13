using NUnit.Framework;

public class TalentAssessmentSystemTests
{
    [Test]
    public void TestFindMedianTalentIndex()
    {
        int[] fireAbility = { 1, 3, 7, 9, 11 };
        int[] iceAbility = { 2, 4, 8, 10, 12, 14 };

        double result = TalentAssessmentSystem.FindMedianTalentIndex(fireAbility, iceAbility);

        Assert.AreEqual(8, result);
    }

    [Test]
    public void TestFindMedianTalentIndex_EvenLength()
    {
        int[] fireAbility = { 1, 2 };
        int[] iceAbility = { 3, 4 };

        double result = TalentAssessmentSystem.FindMedianTalentIndex(fireAbility, iceAbility);

        Assert.AreEqual(2.5, result);
    }

    [Test]
    public void TestFindMedianTalentIndex_SingleElement()
    {
        int[] fireAbility = { };
        int[] iceAbility = { 1 };

        double result = TalentAssessmentSystem.FindMedianTalentIndex(fireAbility, iceAbility);

        Assert.AreEqual(1, result);
    }
}
