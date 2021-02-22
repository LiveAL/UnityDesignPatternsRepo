using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon
{
    public abstract float GetDurability();
    public abstract float GetAccuracy();
    public abstract int GetAmmoAmount();
    public abstract int GetAmmoCapacity();
    public virtual string WeaponModificationsList()
    {
        return "";
    }
}
