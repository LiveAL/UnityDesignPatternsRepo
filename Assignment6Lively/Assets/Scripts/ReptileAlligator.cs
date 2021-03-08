/*
 * Ashton Lively
 * ReptileAlligator.cs
 * Assignment 6
 * Attributes for alligator hatchable
 */
using UnityEngine;

public class ReptileAlligator : Reptile
{
    private float _tailLength;
    private float _weight;
    private int _hitPoints;
    private bool _venomous;
    private PersonalityType _personality;

    public ReptileAlligator()
    {
        float randTail = Random.Range(7f, 7.5f);
        tailLength = randTail;

        int randHP = Random.Range(50, 55);
        hitPoints = randHP;

        float randWeight = Random.Range(100f, 500f);
        weight = randWeight;

        venomous = false;

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
