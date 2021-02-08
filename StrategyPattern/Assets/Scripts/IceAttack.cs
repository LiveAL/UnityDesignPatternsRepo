using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class IceAttack : ElementalAttack, ITakeDamage
{
    private ParticleSystem iceParticles;

    public override void Attack(Transform spawnPos)
    {
        // Spawn particle system for ice
        ParticleSystem particles = Instantiate(iceParticles, spawnPos.transform.position, Quaternion.identity);
        // Destroy particles after 5 seconds
        Destroy(particles, 2f);

        // Freeze in range 
        Collider[] enemiesInRange = Physics.OverlapSphere(particles.transform.position, 4f);
        
        // Spawn particle system for ice on enemies
        foreach (Collider enemy in enemiesInRange)
        {
            ParticleSystem newParticles = Instantiate(iceParticles, enemy.transform.position, Quaternion.identity);
            Destroy(newParticles, 2f);

            TakeDamage(enemy.gameObject);
        }
    }

    public void TakeDamage(GameObject enemyToDamage)
    {
        // Add 3 damage to the enemy 
        enemyToDamage.GetComponent<EnemyBehavior>().UpdateHitPoints(3f);

        // Freeze enemy
        enemyToDamage.GetComponent<EnemyBehavior>().FreezeMovement();
    }

    public override void AssignParticles()
    {
        iceParticles = (ParticleSystem)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Ice.prefab", typeof(ParticleSystem));
    }
}
