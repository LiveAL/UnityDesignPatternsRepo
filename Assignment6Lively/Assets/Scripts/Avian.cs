/*
 * Ashton Lively
 * Avian.cs
 * Assignment 6
 * Attributes for avian type hatchables
 */
using UnityEngine;

public abstract class Avian : MonoBehaviour
{
    public abstract float wingspan { get; set; }
    public abstract int hitPoints { get; set; }
    public enum TalonSize { SMALL, MEDIUM, LARGE}
    public abstract TalonSize talonSize { get; set; }
    public enum PersonalityType { AGGRESSIVE, CUDDLY, LOYAL, ALOOF }
    public abstract PersonalityType personality { get; set; }
    public virtual string toString()
    {
        string str = "";

        str += "Wingspan: " + wingspan + "\nHit Points: " + hitPoints;
        
        switch (talonSize)
        {
            case TalonSize.SMALL:
                str += "\nTalon Size: Small";
                break;
            case TalonSize.MEDIUM:
                str += "\nTalon Size: Medium";
                break;
            case TalonSize.LARGE:
                str += "\nTalon Size: Large";
                break;
        }

        switch (personality)
        {
            case PersonalityType.AGGRESSIVE:
                str += "\nPersonality: Aggressive";
                break;
            case PersonalityType.CUDDLY:
                str += "\nPersonality: Cuddly";
                break;
            case PersonalityType.LOYAL:
                str += "\nPersonality: Loyal";
                break;
            case PersonalityType.ALOOF:
                str += "\nPersonality: Aloof";
                break;
        }

        return str;
    }
}
