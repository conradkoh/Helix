using System;
using System.Collections.Generic;
using Helix.Components.Health;

namespace Helix.Components.Operator
{
    public class Operator: IHealth
    {
        private float _health;
        private string _name;
        private OperatorStats _baseStats;
        private OperatorStats _currentStats;
        private OperatorStats _maxStats;
        private List<Equipment> _equipment = new List<Equipment>();

        public Operator(OperatorStats stats)
        {
            this._baseStats = stats;
            var eqstats = new OperatorStats(this._equipment); //Get the equipment stats from the user
            this._maxStats = OperatorStats.Add(stats, eqstats); 
            this._currentStats = OperatorStats.Add(stats, eqstats);
        }

        public void TakeDamage(float amount)
        {
            this._health -= amount;
        }

        public void Heal(float amount)
        {
            this._health += amount;
        }

        public float GetHealth()
        {
            return this._health;
        }

        public OperatorStats GetStats()
        {
            return this._currentStats;
            
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

