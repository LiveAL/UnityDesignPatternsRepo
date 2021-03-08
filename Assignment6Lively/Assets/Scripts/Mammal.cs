/*
 * Ashton Lively
 * Mammal.cs
 * Assignment 6
 * Attributes for mammal type hatchables
 */
using UnityEngine;

public abstract class Mammal : MonoBehaviour
{
    public enum DietTypes { HERBIVORE, OMNIVORE, CARNIVORE }
    public abstract DietTypes diet { get; set; }
    public abstract int hitPoints { get; set; }
    public enum TailLength { NONE, SHORT, LONG }
    public abstract TailLength tailLength { get; set; }
    public enum PersonalityType { LOYAL, MEAN, CUTE }
    public abstract PersonalityType personality { get; set; }
    public virtual string toString()
    {
        string str = "";

        str += "Hit Points: " + hitPoints;

        switch (diet)
        {
            case DietTypes.HERBIVORE:
                str += "\nDiet: Herbivore";
                break;
            case DietTypes.CARNIVORE:
                str += "\nDiet: Carnivore";
                break;
            case DietTypes.OMNIVORE:
                str += "\nDiet: Omnivore";
                break;
        }

        switch (tailLength)
        {
            case TailLength.LONG:
                str += "\nTail Length: Long";
                break;
            case TailLength.SHORT:
                str += "\nTail Length: Short";
                break;
            case TailLength.NONE:
                str += "\nTail Length: None";
                break;
        }

        switch (personality)
        {
            case PersonalityType.CUTE:
                str += "\nPersonality: Cute";
                break;
            case PersonalityType.MEAN:
                str += "\nPersonality: Mean";
                break;
            case PersonalityType.LOYAL:
                str += "\nPersonality: Loyal";
                break;
        }

        return str;
    }
}

