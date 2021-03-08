/*
 * Ashton Lively
 * MammalHatchery.cs
 * Assignment 6
 * Create a new mammal animal
 */
using UnityEngine;

public class MammalHatchery : Hatchery
{
    /// <summary>
    /// Animal hatched
    /// </summary>
    Mammal mammal;
    private string _animal;

    string attributes = "";

    public enum MammalTypes { LION, WOLF, DEER }

    public override string animal
    {
        get => _animal;
        set => _animal = value;
    }

    public override string AnimalAttributes()
    {
        return attributes;
    }

    public override void HatchAnimal()
    {
        MammalTypes randMammal = (MammalTypes)Random.Range(0, 3);

        switch (randMammal)
        {
            case MammalTypes.LION:
                mammal = new MammalLion();
                animal = "lion";
                break;
            case MammalTypes.DEER:
                mammal = new MammalDeer();
                animal = "deer";
                break;
            case MammalTypes.WOLF:
                mammal = new MammalWolf();
                animal = "wolf";
                break;
        }

        attributes = mammal.toString();
    }
}
