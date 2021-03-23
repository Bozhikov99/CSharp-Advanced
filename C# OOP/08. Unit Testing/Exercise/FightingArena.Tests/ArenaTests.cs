//using FightingArena;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void Count_ReturnsZero_WhenThereAreNoWarriors()
        {
            Assert.AreEqual(arena.Count, 0);
        }

        [Test]
        public void Enroll_ThrowsException_WhenWarriorIsAlreadyEnrolled()
        {
            Warrior warrior = new Warrior("Crixus", 75, 100);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }

        [Test]
        public void Enroll_AddsWarrior()
        {
            Warrior warrior = new Warrior("Crixus", 75, 100);

            arena.Enroll(warrior);
            
            int predictedResult = 1;

            Assert.AreEqual(arena.Count, predictedResult);
        }

        [Test]
        public void Fight_ThrowsException_WhenAWarriorIsNotEnrolled()
        {
            string attackerName = "Crixus";
            string defenderName = "Spartacus";

            Warrior warrior = new Warrior(attackerName, 75, 100);
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, defenderName));
        }

        [Test]
        public void Fight_WarriorsFight_WhenEnrolled()
        {
            string attackerName = "Crixus";
            string defenderName = "Spartacus";

            int initialHp = 100;

            Warrior attacker = new Warrior(attackerName, 75, initialHp);
            Warrior defender = new Warrior(defenderName, 90, initialHp);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attackerName, defenderName);

            Assert.AreEqual(attacker.HP, initialHp - defender.Damage);
            Assert.AreEqual(defender.HP, initialHp - attacker.Damage);
        }
    }
}
