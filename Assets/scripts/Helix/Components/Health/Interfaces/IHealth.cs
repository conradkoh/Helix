using System;

namespace Helix.Components.Health
{
    public interface IHealth
    {
        void TakeDamage(float amount);

        void Heal(float amount);
    }
}