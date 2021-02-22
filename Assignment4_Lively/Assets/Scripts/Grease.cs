/* 
 * Ashton Lively
 * Grease.cs
 * Assignment 4
 * Adds properties for when the player oils the gun.
 */
using UnityEngine;

public class Grease : WeaponUpgradeDecorator
{
    Weapon weapon;

    public Grease(Weapon weapon)
    {
        this.weapon = weapon;
    }
    public override float GetAccuracy()
    {
        return weapon.GetAccuracy();
    }
    public override int GetAmmoCapacity()
    {
        return weapon.GetAmmoCapacity();
    }
    public override int GetAmmoAmount()
    {
        return weapon.GetAmmoAmount();
    }
    public override float GetDurability()
    {
        float durability = weapon.GetDurability() + .3f;
        durability = Mathf.Clamp(durability, 0, 1);
        return durability;
    }

    public override string WeaponModificationsList()
    {
        return weapon.WeaponModificationsList() + " greased";
    }
}
