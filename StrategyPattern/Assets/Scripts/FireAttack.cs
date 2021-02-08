/* 
 * Ashton Lively
 * FireAttack.cs
 * Assignment 2
 * Contains behavior for the fire attack type for its damage and appearance.
 */
using System.Collections;
using UnityEngine;

public class FireAttack : ElementalAttack, ITakeDamage
{
    private ParticleSystem fireParticles;

    public override void Attack(Transform spawnPos)
    {
        // Spawn particle system for fire
        ParticleSystem particles = Instantiate(fireParticles, spawnPos.transform.position, Quaternion.identity);
        // Destroy particles after 5 seconds
        Destroy(particles, 2f);

        // Set in range on fire. 
        Collider[] enemiesInRange = Physics.OverlapSphere(particles.transform.position, 4f);

        // Spawn particle system for fire on enemies
        foreach (Collider enemy in enemiesInRange)
        {
            //particlesOnEnemies.Add(Instantiate(fireParticles, enemy.transform));
            ParticleSystem newParticles = Instantiate(fireParticles, enemy.transform.position, Quaternion.identity);
            Destroy(newParticles, 2f);

            TakeDamage(enemy.gameObject);
        }
    }

    public void TakeDamage(GameObject enemyToDamage)
    {
        StartCoroutine(TakeDamageRepeating(enemyToDamage));
    }

    private IEnumerator TakeDamageRepeating(GameObject enemy)
    {
        float timeElapsed = 0;
        while (timeElapsed < 5f)
        {
            timeElapsed += Time.deltaTime;
            yield return new WaitForSeconds(0.5f);

            // Add 1 damage to the enemy every half second
            if (enemy != null)
            {
                enemy.GetComponent<EnemyBehavior>().UpdateHitPoints(1);
            }
        }
    }

    public override void AssignParticles()
    {
        fireParticles = (ParticleSystem)Resources.Load("Prefabs/Fire", typeof(ParticleSystem));
    }
}