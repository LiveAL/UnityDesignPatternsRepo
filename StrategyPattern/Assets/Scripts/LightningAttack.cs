using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LightningAttack : ElementalAttack, ITakeDamage
{
    private ParticleSystem lightningParticles;

    private List<GameObject> objectsElectrocuted = new List<GameObject>();

    public override void Attack(Transform spawnPos)
    {
        // Spawn particle system for lightning
        ParticleSystem particles = Instantiate(lightningParticles, spawnPos.transform.position, Quaternion.identity);
        // Destroy particles after 2 seconds
        Destroy(particles, 2f);

        // Electrocute in range 
        Collider[] enemiesInRange = Physics.OverlapSphere(particles.transform.position, 4f);

        // Spawn particle system for lightning on enemies
        foreach (Collider enemy in enemiesInRange)
        {
            if (!objectsElectrocuted.Contains(enemy.gameObject))
            {
                objectsElectrocuted.Add(enemy.gameObject);
                StartCoroutine(RemoveObjectNotElectrocuted(enemy.gameObject));

                ParticleSystem newParticles = Instantiate(lightningParticles, enemy.transform.position, Quaternion.identity);
                Destroy(newParticles, 2f);

                TakeDamage(enemy.gameObject);
            }
        }
    }

    public void TakeDamage(GameObject enemyToDamage)
    {
        // Add 5 damage to the enemy 
        if (enemyToDamage != null)
        {
            enemyToDamage.GetComponent<EnemyBehavior>().UpdateHitPoints(5);
        }

        // Damage enemies within range as well
        Collider[] inRange = Physics.OverlapSphere(enemyToDamage.transform.position, 4f);

        // Spawn particle system for lightning on enemies
        foreach (Collider enemy in inRange)
        {
            if (!objectsElectrocuted.Contains(enemy.gameObject))
            {
                objectsElectrocuted.Add(enemy.gameObject);
                StartCoroutine(RemoveObjectNotElectrocuted(enemy.gameObject));

                ParticleSystem newParticles = Instantiate(lightningParticles, enemy.transform);
                Destroy(newParticles, 2f);

                TakeDamage(enemy.gameObject);
            }
        }
    }

    private IEnumerator RemoveObjectNotElectrocuted(GameObject removeThis)
    {
        yield return new WaitForSeconds(2f);

        objectsElectrocuted.Remove(removeThis);
    }

    public override void AssignParticles()
    {
        lightningParticles = (ParticleSystem)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Lightning.prefab", typeof(ParticleSystem));
    }
}
