/*
 * Ashton Lively
 * Horse.cs
 * Assignment 5
 * Creates a horse with or without parents.
 */
using UnityEngine;

public class Horse : MonoBehaviour
{
    /// <summary>
    /// First parent of the horse
    /// </summary>
    private Horse _parent1;
    /// <summary>
    /// Second parent of the horse
    /// </summary>
    private Horse _parent2;
    /// <summary>
    /// Horse breeding factory class
    /// </summary>
    private HorseBreeder _breeder;

    /// <summary>
    /// Create a horse with no parents
    /// </summary>
    public Horse()
    {
        this._breeder = new HorseBreeder();
        _breeder.CreateBody();
        _breeder.CreateHead();
        _breeder.CreateTail();
    }

    /// <summary>
    /// Create a horse with parents
    /// </summary>
    /// <param name="parent1">First parent of the horse</param>
    /// <param name="parent2">Second parent of the horse</param>
    public Horse(Horse parent1, Horse parent2)
    {
        this._parent1 = parent1;
        this._parent2 = parent2;

        this._breeder = new HorseBreeder();

        _breeder.CreateBody(parent1, parent2);
        _breeder.CreateHead(parent1, parent2);
        _breeder.CreateTail(parent1, parent2);

    }

    public Body GetBody()
    {
        return _breeder.GetBody();
    }

    public Body GetBodyAllele1()
    {
        return _breeder.GetBodyAllele1();
    }

    public Body GetBodyAllele2()
    {
        return _breeder.GetBodyAllele2();
    }

    public Head GetHead()
    {
        return _breeder.GetHead();
    }

    public Head GetHeadAllele1()
    {
        return _breeder.GetHeadAllele1();
    }

    public Head GetHeadAllele2()
    {
        return _breeder.GetHeadAllele2();
    }

    public Tail GetTail()
    {
        return _breeder.GetTail();
    }

    public Tail GetTailAllele1()
    {
        return _breeder.GetTailAllele1();
    }

    public Tail GetTailAllele2()
    {
        return _breeder.GetTailAllele2();
    }
}
