/*
 * Ashton Lively
 * ReptileHatchery.cs
 * Assignment 6
 * Create a new reptile animal
 */
using UnityEngine;

public class ReptileHatchery : Hatchery
{
    /// <summary>
    /// Animal hatched
    /// </summary>
    Reptile reptile;
    private string _animal;

    string attributes = "";

    public override string animal
    {
        get => _animal;
        set => _animal = value;
    }

    public enum ReptileTypes { IGUANA, ALLIGATOR, PYTHON }

    public override string AnimalAttributes()
    {
        return attributes;
    }

    public override void HatchAnimal()
    {
        ReptileTypes randReptile = (ReptileTypes)Random.Range(0, 3);

        switch (randReptile)
        {
            case ReptileTypes.IGUANA:
                reptile = new ReptileIguana();
                animal = "iguana";
                break;
            case ReptileTypes.ALLIGATOR:
                reptile = new ReptileAlligator();
                animal = "alligator";
                break;
            case ReptileTypes.PYTHON:
                reptile = new ReptilePython();
                animal = "python";
                break;
        }

        attributes = reptile.toString();
    }
}
