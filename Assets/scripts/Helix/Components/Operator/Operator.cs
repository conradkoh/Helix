using System;
using System.Collections.Generic;
using Helix.Components.Health;
using UnityEngine;

namespace Helix.Components.Operator
{
    public class Operator: IHealth
    {
        private string _name;
        private OperatorStats _baseStats;
        private OperatorStats _currentStats;
        private OperatorStats _maxStats;
        private List<Equipment> _equipment = new List<Equipment>();

        public OperatorEvent HealthUpdated;

        public Operator(OperatorStats stats)
        {
            this._baseStats = stats;
            var eqstats = new OperatorStats(this._equipment); //Get the equipment stats from the user
            this._maxStats = OperatorStats.Add(stats, eqstats); 
            this._currentStats = OperatorStats.Add(stats, eqstats);
        }

        public void TakeDamage(float amount)
        {
            this._currentStats.health -= amount;

            if (HealthUpdated != null)
            {
                HealthUpdated(this);
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


        public List<Equipment> GetEquipment()
        {
            return this._equipment;
        }

        public string GetSummary()
        {
            return String.Format("Current Stats: {0}, Max Stats: {1}", this._currentStats.GetSummary(), this._maxStats.GetSummary());
        }
    }
}

