using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : WeaponUpgradeDecorator
{
    Weapon weapon;

    public GunShot(Weapon weapon)
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
        int ammunitionAmt = weapon.GetAmmoAmount() - 1;
        ammunitionAmt = Mathf.Clamp(ammunitionAmt, 0, weapon.GetAmmoCapacity());
        return ammunitionAmt;
    }

    public override float GetDurability()
    {
        return weapon.GetDurability() - .1f;
    }

    public override string WeaponModificationsList()
    {
        return weapon.WeaponModificationsList() + " that fired a shot";
    }
}
