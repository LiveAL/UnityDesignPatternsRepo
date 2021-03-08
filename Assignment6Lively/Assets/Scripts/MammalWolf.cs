/*
 * Ashton Lively
 * MammalWolf.cs
 * Assignment 6
 * Attributes for wolf hatchable
 */
using UnityEngine;

public class MammalWolf : Mammal
{
    private DietTypes _diet;
    private int _hitPoints;
    private TailLength _tailLength;
    private PersonalityType _personality;

    public MammalWolf()
    {
        diet = DietTypes.CARNIVORE;

        int randHP = Random.Range(15, 18);
        hitPoints = randHP;

        tailLength = TailLength.LONG;

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
