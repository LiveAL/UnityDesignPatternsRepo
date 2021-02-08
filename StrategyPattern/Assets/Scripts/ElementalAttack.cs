/* 
 * Ashton Lively
 * ElementalAttack.cs
 * Assignment 2
 * Abstract class for elemental attack types.
 */
using UnityEngine;

public abstract class ElementalAttack : MonoBehaviour
{
    public abstract void Attack(Transform spawnPos);

    public abstract void AssignParticles();
}
