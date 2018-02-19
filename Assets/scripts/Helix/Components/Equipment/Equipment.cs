using System;
using System.Collections.Generic;
using Helix.Components.Equipment;

namespace Helix.Components.Operator
{
    public abstract class Equipment
    {
        public float health = 0;
        public float armor = 0;
        public float attack = 0;
        public float armorPenetration = 0;
        public float movementSpeed = 0;
        public string name = "";
        public string description = "";

        public Equipment(string name, string description, Dictionary<EquipmentStats, float> properties)
        {
            this.name = name;
            this.description = description;

            foreach (KeyValuePair<EquipmentStats, float> item in properties)
            {
                switch (item.Key)
                {
                    case EquipmentStats.HEALTH:
                        this.health = item.Value;
                        break;
                    case EquipmentStats.ARMOR:
                        this.armor = item.Value;
                        break;
                    case EquipmentStats.ATTACK:
                        this.attack = item.Value;
                        break;
                    case EquipmentStats.ARMOR_PENETRATION:
                        this.armorPenetration = item.Value;
                        break;
                    case EquipmentStats.MOVEMENT_SPEED:
                        this.movementSpeed = item.Value;
                        break;
                }
            }
        }
    }
}

