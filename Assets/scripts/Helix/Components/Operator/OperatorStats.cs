using System;
using System.Collections.Generic;
using UnityEngine;

namespace Helix.Components.Operator
{
    public class OperatorStats
    {
        public float health = 0;
        public float armor = 0;
        public float attack = 0;
        public float armorPenetration = 0;
        public float movementSpeed = 0;

        public OperatorStats(List<Equipment> equipment)
        {
            foreach (Equipment eq in equipment)
            {
                this.Equip(eq);
            }
        }

        public OperatorStats(float health, float armor = 0, float attack = 0, float armorPenetration = 0, float movementSpeed = 0)
        {
            this.health = health;
            this.armor = armor;
            this.attack = attack;
            this.armorPenetration = armorPenetration;
            this.movementSpeed = movementSpeed;
        }

        public static OperatorStats Add(OperatorStats stats1, OperatorStats stats2)
        {
            return new OperatorStats(
                stats1.health + stats2.health,
                stats1.armor + stats2.armor,
                stats1.attack + stats2.attack,
                stats1.armorPenetration + stats2.armorPenetration,
                stats1.movementSpeed + stats2.movementSpeed
            );
        }

        public void Equip(Equipment eq)
        {
            this.health += eq.health;
            this.armor += eq.armor;
            this.attack += eq.attack;
            this.armorPenetration += eq.armorPenetration;
            this.movementSpeed += eq.movementSpeed;
        }

        public void UnEquip(Equipment eq)
        {
            this.health -= eq.health;
            this.armor -= eq.armor;
            this.attack -= eq.attack;
            this.armorPenetration -= eq.armorPenetration;
            this.movementSpeed -= eq.movementSpeed;
        }

        public float GetHealth()
        {
            return this.health;
        }

        public float GetArmor()
        {
            return this.armor;
        }

        public float GetAttack()
        {
            return this.attack;
        }

        public float GetArmorPenetration()
        {
            return this.armorPenetration;
        }

        public float GetMovementSpeed()
        {
            return this.movementSpeed;
        }

        public string GetSummary()
        {
            return String.Format("Health: {0}, Armor: {1}, Attack: {2}, Armor Penetration: {3}, Movement Speed: {4}", this.health, this.armor, this.attack, this.armorPenetration, this.movementSpeed);
        }
    }
}

