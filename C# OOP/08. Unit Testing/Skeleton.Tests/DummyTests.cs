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

        Assert.AreEqual(health - 2, testDummy.Health);
    }

    [Test]
    public void When_AttackedDead_ThrowException()
    {
        testDummy = new Dummy(0, 2);

        Assert.Throws<InvalidOperationException>(() =>
        {
            testDummy.TakeAttack(1);
        });
    }

    [Test]
    public void When_Dead_GiveXP()
    {
        int experience = 2;
        testDummy = new Dummy(0, experience);

        Assert.AreEqual(testDummy.GiveExperience(), experience);
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
