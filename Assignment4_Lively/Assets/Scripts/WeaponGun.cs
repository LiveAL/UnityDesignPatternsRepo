/* 
 * Ashton Lively
 * WeaponGun.cs
 * Assignment 4
 * Adds properties for if the player has the handgun equipped.
 */

public class WeaponHandgun : Weapon
{
    public override float GetAccuracy()
    {
        return .50f;
    }

    public override int GetAmmoAmount()
    {
        return 0;
    }

    public override int GetAmmoCapacity()
    {
        return 6;
    }

    public override float GetDurability()
    {
        return 1f;
    }

    public override string WeaponModificationsList()
    {
        return base.WeaponModificationsList() + "Handgun";
    }
}
