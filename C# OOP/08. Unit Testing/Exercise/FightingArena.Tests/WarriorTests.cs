//using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("", 25, 50)]
        [TestCase(null, 25, 50)]
        [TestCase("  ", 25, 50)]
        [TestCase("WarriorName", 0, 50)]
        [TestCase("WarriorName", -25, 50)]
        [TestCase("WarriorName", 25, -1)]
        public void Constructor_ThrowsException_WhenDataIsInvalid(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(()=>new Warrior(name, damage , hp));
        }

        [Test]
        [TestCase(15,50)]
        [TestCase(30,50)]
        [TestCase(50,15)]
        [TestCase(50,30)]
        public void Attack_ThrowsException_WhenHpIsTooLow(int attackerHp,int defenderHp)
        {
            Warrior attacker = new Warrior("Attacker", 10, attackerHp);
            Warrior defender = new Warrior("Defender", 10, defenderHp);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void Attack_EnemyIsTooStrong()
        {
            Warrior attacker = new Warrior("Attacker", 50, 100);
            Warrior defender = new Warrior("Defender", attacker.HP+1, 100);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void Attack_ReducesAttackerHp()
        {
            int initialHp = 100;

            Warrior attacker = new Warrior("AttackerName", 75, initialHp);
            Warrior defender = new Warrior("DefenderName", 25, initialHp);

            attacker.Attack(defender);

            Assert.AreEqual(attacker.HP, initialHp-defender.Damage);
        }

        [Test]
        public void Attack_DealsDamage()
        {
            int initialHp = 100;

            Warrior attacker = new Warrior("AttackerName", 75, 100);
            Warrior defender = new Warrior("Defender", 75, 100);

            attacker.Attack(defender);

            Assert.AreEqual(defender.HP, 25);
        }

        [Test]
        public void Attack_SetsHPToZero_WhenIsTooStrong()
        {
            Warrior attacker = new Warrior("AttackerName", 75, 100);
            Warrior defender = new Warrior("DefenderName", 1, 31);

            attacker.Attack(defender);

            Assert.That(defender.HP == 0);
        }

        [Test]
        public void Attack_LowersDefenderHP()
        {
            int initialHp = 100;

            Warrior attacker = new Warrior("AttackerName", 75, initialHp);
            Warrior defender = new Warrior("DefenderName", 75, initialHp);

            attacker.Attack(defender);

            Assert.AreEqual(defender.HP, initialHp - attacker.Damage);
        }

    }
}