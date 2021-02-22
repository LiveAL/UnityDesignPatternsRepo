/* 
 * Ashton Lively
 * Weapon.cs
 * Assignment 4
 * Abstract class for the created weapons.
 */

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
