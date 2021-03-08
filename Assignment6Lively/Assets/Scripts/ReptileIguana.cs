/*
 * Ashton Lively
 * ReptileIguana.cs
 * Assignment 6
 * Attributes for iguana hatchable
 */
using UnityEngine;

public class ReptileIguana : Reptile
{
    private float _tailLength;
    private float _weight;
    private int _hitPoints;
    private bool _venomous;
    private PersonalityType _personality;

    public ReptileIguana()
    {
        float randTail = Random.Range(1, 5f);
        tailLength = randTail;

        int randHP = Random.Range(5, 10);
        hitPoints = randHP;

        float randWeight = Random.Range(3, 31);
        weight = randWeight;

        venomous = true;

        PersonalityType randPersonality = (PersonalityType)Random.Range(0, 4);
        personality = randPersonality;
    }

    public override float tailLength
    {
        get => _tailLength;
        set => _tailLength = value;
    }
    public override float weight
    {
        get => _weight;
        set => _weight = value;
    }

    public override int hitPoints
    {
        get => _hitPoints;
        set => _hitPoints = value;
    }

    public override bool venomous
    {
        get => _venomous;
        set => _venomous = value;
    }

    public override PersonalityType personality
    {
        get => _personality;
        set => _personality = value;
    }
}
