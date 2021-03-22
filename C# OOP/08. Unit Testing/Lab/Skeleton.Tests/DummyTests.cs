using NUnit.Framework;
using NUnit.Framework.Internal;
using System;

[TestFixture]
public class DummyTests
{
    private int health;
    private int xp;

    private Dummy testDummy;
    [SetUp]
    public void SetUp()
    {
        health = 4;
        xp = 4;

        testDummy = new Dummy(health, xp);
    }

    [Test]
    public void When_Attacked_LoseHp()
    {
        int attack = 2;

        testDummy.TakeAttack(attack);

        Assert.That(health - 2== testDummy.Health, "The dummy should lose health when attacked.");
    }

    [Test]
    public void When_AttackedDead_ThrowException()
    {
        int dummyHealth = 0;
        int dummyXP = 2;

        testDummy = new Dummy(dummyHealth, dummyXP);

        Assert.Throws<InvalidOperationException>(() =>
        {
            testDummy.TakeAttack(1);
        });
    }

    [Test]
    public void When_Dead_GiveXP()
    {
        int dummyHealth = 0;
        int experience = 2;

        testDummy = new Dummy(dummyHealth, experience);

        Assert.That(testDummy.GiveExperience()==experience, "The dead dummy must give experience.");
    }

    [Test]
    public void When_Alive_ThrowsExceptionXP()
    {
        InvalidOperationException x = Assert.Throws<InvalidOperationException>(() =>
          {
              testDummy.GiveExperience();
          });

        Assert.AreEqual(x.Message, "Target is not dead.");
    }
}
