﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRifle : Weapon
{
    public override float GetAccuracy()
    {
        return .80f;
    }

    public override int GetAmmoAmount()
    {
        return 0;
    }

    public override int GetAmmoCapacity()
    {
        return 24;
    }

    public override float GetDurability()
    {
        return 1f;
    }
    public override string WeaponModificationsList()
    {
        return base.WeaponModificationsList() + "Rifle";
    }
}
