using System;
using System.Collections.Generic;
using Helix.Components.Health;
using Helix.Components.Equipment;
using UnityEngine;

namespace Helix.Components.Operator
{
    public class Operator: IHealth
    {
        private string _name;
        private OperatorStats _baseStats;
        private OperatorStats _currentStats;
        private OperatorStats _maxStats;
        private EquipmentSet _equipmentSet = new EquipmentSet();

        public OperatorEvent HealthUpdated;
        public OperatorEvent OperatorDied;

        public Operator(OperatorStats stats)
        {
            this._baseStats = stats;
            var eqstats = new OperatorStats(this._equipmentSet); //Get the equipment stats from the user
            this._maxStats = OperatorStats.Add(this._baseStats, eqstats); 
            this._currentStats = OperatorStats.Add(this._baseStats, eqstats);
        }

        public void TakeDamage(float amount)
        {
            this._currentStats.health -= amount;

            if (HealthUpdated != null)
            {
                HealthUpdated(this);
            }
            if (this._currentStats.health <= 0)
            {
                if (this.OperatorDied != null)
                {
                    OperatorDied(this);
                }
            }
        }

        public void Heal(float amount)
        {
            this._currentStats.health += amount;

            if (HealthUpdated != null)
            {
                HealthUpdated(this);
            }
        }

        public float GetHealth()
        {
            return this._currentStats.health;
        }

        public OperatorStats GetStats()
        {
            return this._currentStats;            
        }

        public OperatorStats GetMaxStats()
        {
            return this._maxStats;
        }

        public void Equip(Item item, bool debug = true)
        {
            this._equipmentSet.Equip(item);
            var eqstats = new OperatorStats(this._equipmentSet); //Get the equipment stats from the user
            this._maxStats = OperatorStats.Add(this._baseStats, eqstats); 
            this._currentStats = OperatorStats.Add(this._baseStats, eqstats);
            if (debug)
            {
                Debug.Log("Equipping item.");
            }
        }

        public string GetSummary()
        {
            return String.Format("Current Stats: {0}, Max Stats: {1}", this._currentStats.GetSummary(), this._maxStats.GetSummary());
        }
    }
}

