using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterGrip : WeaponUpgradeDecorator
{
    Weapon weapon;

    public BetterGrip(Weapon weapon)
    {
        this.weapon = weapon;
    }

    public override float GetAccuracy()
    {
        float accuracy = weapon.GetAccuracy() + .1f;
        accuracy = Mathf.Clamp(accuracy, 0, 1);
        return accuracy;
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
        return weapon.GetDurability();
    }
    public override string WeaponModificationsList()
    {
        return weapon.WeaponModificationsList() + " with a better grip";
    }
}
