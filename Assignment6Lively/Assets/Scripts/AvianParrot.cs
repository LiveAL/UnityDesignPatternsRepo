/*
 * Ashton Lively
 * AvianParrot.cs
 * Assignment 6
 * Attributes for parrot hatchable
 */
using UnityEngine;

public class AvianParrot : Avian
{
    private float _wingspan;
    private int _hitPoints;
    private TalonSize _talonSize;
    private PersonalityType _personality;

    public AvianParrot()
    {
        float randWingspan = Random.Range(3.4f, 4.1f);
        wingspan = randWingspan;

        int randHP = Random.Range(5, 13);
        hitPoints = randHP;

        TalonSize randTalons = (TalonSize)Random.Range(0, 2);
        talonSize = randTalons;

        PersonalityType randPersonality = (PersonalityType)Random.Range(0, 3);
        personality = randPersonality;
    }

    public override float wingspan
    {
        get => _wingspan;
        set => _wingspan = value;
    }

    public override int hitPoints
    {
        get => _hitPoints;
        set => _hitPoints = value;
    }

    public override TalonSize talonSize
    {
        get => _talonSize;
        set => _talonSize = value;
    }

    public override PersonalityType personality
    {
        get => _personality;
        set => _personality = value;
    }
}
