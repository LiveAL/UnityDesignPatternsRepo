/* 
 * Ashton Lively
 * NoWeapon.cs
 * Assignment 4
 * Adds properties for if the player has nothing equipped. 
 */

public class NoWeapon : Weapon
{
    public override float GetAccuracy()
    {
        return 0f;
    }

    public override int GetAmmoAmount()
    {
        return 0;
    }

    public override int GetAmmoCapacity()
    {
        return 0;
    }

    public override float GetDurability()
    {
        return 0f;
    }

    public virtual string WeaponModificationsList()
    {
        return "Weapon Unequipped";
    }
}
