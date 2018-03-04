using System;
using UnityEngine;
using Helix.Components.Operator;

public class ShouldDealDamageArgs
{
    public Operator damageReceiver;
    public DamageType damageType;
    public float damageAmount;

    public ShouldDealDamageArgs(Operator receiver, DamageType damageType, float damageAmount)
    {
        this.damageReceiver = receiver;
        this.damageType = damageType;
        this.damageAmount = damageAmount;     
    }
}

public delegate void ShouldDealDamage(System.Object sender,ShouldDealDamageArgs args);

public enum DamageType
{
    physical,
    magic
}

