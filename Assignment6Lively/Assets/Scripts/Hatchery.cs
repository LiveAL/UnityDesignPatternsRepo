/*
 * Ashton Lively
 * Hatchery.cs
 * Assignment 6
 * Methods for creating new animals
 */
using UnityEngine;

public abstract class Hatchery : MonoBehaviour
{
    /// <summary>
    /// Hatch a new animal
    /// </summary>
    public abstract void HatchAnimal();
    /// <summary>
    /// Return the attributes of the animal
    /// </summary>
    /// <returns></returns>
    public abstract string AnimalAttributes();
    public abstract string animal { get; set; }
}
