/*
 * Ashton Lively
 * ReptilePython.cs
 * Assignment 6
 * Attributes for python hatchable
 */
using UnityEngine;

public class ReptilePython : Reptile
{
    private float _tailLength;
    private float _weight;
    private int _hitPoints;
    private bool _venomous;
    private PersonalityType _personality;

    public ReptilePython()
    {
        float randTail = Random.Range(23f, 33f);
        tailLength = randTail;

        int randHP = Random.Range(5, 25);
        hitPoints = randHP;

        float randWeight = Random.Range(27, 200);
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