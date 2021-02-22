using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendedMag : WeaponUpgradeDecorator
{
    Weapon weapon;

    public ExtendedMag(Weapon weapon)
    {
        this.weapon = weapon;
    }
    public override float GetAccuracy()
    {
        return weapon.GetAccuracy();
    }
    public override int GetAmmoCapacity()
    {
        return weapon.GetAmmoCapacity() + 5;
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
        return weapon.WeaponModificationsList() + " with extended mag";
    }
}
