using System;
using UnityEngine;


public class ShouldDealDamageArgs
{
    public GameObject damageReceiver;
    public DamageType damageType;
    public float damageAmount;

    public ShouldDealDamageArgs(GameObject receiver, DamageType damageType, float damageAmount)
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

