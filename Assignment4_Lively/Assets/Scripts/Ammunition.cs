/* 
 * Ashton Lively
 * Ammunition.cs
 * Assignment 4
 * Adds properties for when the player adds a piece of ammo. 
 */
using UnityEngine;

public class Ammunition : WeaponUpgradeDecorator
{
    Weapon weapon;

    public Ammunition(Weapon weapon)
    {
        this.weapon = weapon;
    }

    public override float GetAccuracy()
    {
        return weapon.GetAccuracy();
    }

    public override int GetAmmoAmount()
    {
        int ammunitionAmt = weapon.GetAmmoAmount() + 1;
        ammunitionAmt = Mathf.Clamp(ammunitionAmt, 0, weapon.GetAmmoCapacity());
        return ammunitionAmt;
    }

    public override int GetAmmoCapacity()
    {
        return weapon.GetAmmoCapacity();
    }

    public override float GetDurability()
    {
        return weapon.GetDurability();
    }

    public override string WeaponModificationsList()
    {
        return weapon.WeaponModificationsList() + " with added ammunition";
    }
}
