/*
 * Ashton Lively
 * Reptile.cs
 * Assignment 6
 * Attributes for reptile type hatchables
 */
using UnityEngine;

public abstract class Reptile : MonoBehaviour
{
    public abstract float tailLength { get; set; }
    public abstract int hitPoints { get; set; }
    public abstract bool venomous { get; set; }
    public abstract float weight { get; set; }
    public enum PersonalityType { AGGRESSIVE, STUPID, HELPFUL, NICE, CUTE }
    public abstract PersonalityType personality { get; set; }
    public virtual string toString()
    {
        string str = "";

        str += "Tail Length: " + tailLength + "\nHit Points: " + hitPoints + "\nVenomous: " + venomous + "\nWeight: " + weight;

        switch (personality)
        {
            case PersonalityType.AGGRESSIVE:
                str += "\nPersonality: Aggressive";
                break;
            case PersonalityType.STUPID:
                str += "\nPersonality: Stupid";
                break;
            case PersonalityType.HELPFUL:
                str += "\nPersonality: Helpful";
                break;
            case PersonalityType.NICE:
                str += "\nPersonality: Nice";
                break;
            case PersonalityType.CUTE:
                str += "\nPersonality: Cute";
                break;
        }

        return str;
    }
}

