/* 
 * Ashton Lively
 * WeaponBuilder.cs
 * Assignment 4
 * Creates and adds properties of a player created gun. 
 */
using UnityEngine;
using UnityEngine.UI;

public class WeaponBuilder : MonoBehaviour
{
    [Tooltip("Description text of the gun.")]
    public Text description;
    [Tooltip("Accuracy percentage text.")]
    public Text accuracy;
    [Tooltip("Durability percentage text.")]
    public Text durability;
    [Tooltip("Amount of ammo text.")]
    public Text ammunitionAmt;

    private Weapon weapon;

    /// <summary>
    /// Equip or unequip the gun
    /// </summary>
    /// <param name="weaponType">Type of weapon being equipped</param>
    public void Equip(string weaponType)
    {
        switch (weaponType)
        {
            case "Handgun":
                this.weapon = new WeaponHandgun();
                break;
            case "Rifle":
                this.weapon = new WeaponRifle();
                break;
            default:
                this.weapon = new NoWeapon();
                break;
        }

        UpdateDescription();
    }

    /// <summary>
    /// Modify the gun
    /// </summary>
    /// <param name="mod">Mod type</param>
    public void NewWeaponMod(string mod) 
    {
        switch (mod) {
            case "Shot":
                if (this.weapon.GetAmmoAmount() > 0)
                {
                    this.weapon = new GunShot(weapon);
                }
                break;
            case "Ammo":
                if (this.weapon.GetAmmoAmount() < this.weapon.GetAmmoCapacity())
                {
                    this.weapon = new Ammunition(weapon);
                }
                break;
            case "BetterGrip":
                this.weapon = new BetterGrip(weapon);
                break;
            case "ExtendedMag":
                this.weapon = new ExtendedMag(weapon);
                break;
            case "Grease":
                this.weapon = new Grease(weapon);
                break;
        }

        UpdateDescription();
    }

    /// <summary>
    /// Update the description of the gun.
    /// </summary>
    public void UpdateDescription()
    {
        description.text = weapon.WeaponModificationsList();
        accuracy.text = Mathf.FloorToInt(weapon.GetAccuracy()  * 100) + "%";
        durability.text = Mathf.FloorToInt(weapon.GetDurability() * 100) + "%";
        ammunitionAmt.text = weapon.GetAmmoAmount() + "/" + weapon.GetAmmoCapacity();
    }

}
