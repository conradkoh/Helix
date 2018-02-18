using System;
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

        public OperatorStats(Operator op)
        {
            var equipment = op.GetEquipment();
            foreach (Equipment eq in equipment)
            {
                this.health += eq.health;
                this.armor += eq.armor;
                this.attack += eq.attack;
                this.armorPenetration += eq.armorPenetration;
                this.movementSpeed += eq.movementSpeed;
            }
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

