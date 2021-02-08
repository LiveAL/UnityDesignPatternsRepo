using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ElementalAttack : MonoBehaviour
{
    public abstract void Attack(Transform spawnPos);

    public abstract void AssignParticles();
}
