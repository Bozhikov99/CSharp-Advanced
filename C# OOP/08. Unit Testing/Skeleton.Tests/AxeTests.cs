using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private int attack;
    private int durability;

    private Axe axe;
    private Dummy target;

    [SetUp]
    public void SetUp()
    {
        attack = 1;
        durability = 1;
        axe = new Axe(attack, durability);

        target = new Dummy(2, 2);
    }

    [Test]
    public void When_Attack_LoseDurability()
    {
        axe.Attack(target);

        Assert.AreEqual(axe.DurabilityPoints, durability - 1);
    }

    [Test]
    public void When_AttackWithBrokenAxe_ThrowException()
    {
        Assert.Throws<InvalidOperationException>(() =>
        {
            for (int i = 0; i < 3; i++)
            {
                axe.Attack(target);
            }
        });

    }
}