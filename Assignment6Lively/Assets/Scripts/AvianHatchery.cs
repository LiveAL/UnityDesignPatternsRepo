/*
 * Ashton Lively
 * AvianHatchery.cs
 * Assignment 6
 * Create a new avian animal
 */
using UnityEngine;

public class AvianHatchery : Hatchery
{
    /// <summary>
    /// Animal hatched
    /// </summary>
    private Avian avian;
    private string _animal;

    private string attributes = "";

    public override string animal
    {
        get => _animal;
        set => _animal = value;
    }

    public enum AvianTypes { HAWK, PARROT, FALCON }

    public override string AnimalAttributes()
    {
        return attributes;
    }

    public override void HatchAnimal()
    {
        AvianTypes randAvian = (AvianTypes)Random.Range(0, 3);

        switch (randAvian)
        {
            case AvianTypes.HAWK:
                avian = new AvianHawk();
                animal = "hawk";
                break;
            case AvianTypes.FALCON:
                avian = new AvianFalcon();
                animal = "falcon";
                break;
            case AvianTypes.PARROT:
                avian = new AvianParrot();
                animal = "parrot";
                break;
        }

        attributes = avian.toString();
    }
}
