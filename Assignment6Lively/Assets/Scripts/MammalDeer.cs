/*
 * Ashton Lively
 * MammalDeer.cs
 * Assignment 6
 * Attributes for deer hatchable
 */
using UnityEngine;

public class MammalDeer : Mammal
{
    private DietTypes _diet;
    private int _hitPoints;
    private TailLength _tailLength;
    private PersonalityType _personality;

    public MammalDeer()
    {
        diet = DietTypes.HERBIVORE;

        int randHP = Random.Range(10, 12);
        hitPoints = randHP;

        tailLength = TailLength.SHORT;

        PersonalityType randPersonality = (PersonalityType)Random.Range(0, 2);
        personality = randPersonality;
    }

    public override DietTypes diet
    {
        get => _diet;
        set => _diet = value;
    }

    public override int hitPoints
    {
        get => _hitPoints;
        set => _hitPoints = value;
    }

    public override TailLength tailLength
    {
        get => _tailLength;
        set => _tailLength = value;
    }

    public override PersonalityType personality
    {
        get => _personality;
        set => _personality = value;
    }
}
