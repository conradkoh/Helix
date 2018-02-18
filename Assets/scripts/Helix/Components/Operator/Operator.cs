using System;
using System.Collections.Generic;
using Helix.Components.Health;

namespace Helix.Components.Operator
{
    public class Operator: IHealth
    {
        private float _health;
        private string _name;
        private OperatorStats _currentStats;
        private OperatorStats _maxStats;
        private List<Equipment> _equipment = new List<Equipment>();

        public Operator(float health)
        {
            this._health = health;
            this._maxStats = new OperatorStats(this);
            this._currentStats = new OperatorStats(this);
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
            return String.Format("Health: {0}, {1}", this._health, this._currentStats.GetSummary());
        }
    }
}

