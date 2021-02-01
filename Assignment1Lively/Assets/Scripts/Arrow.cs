/*
 * Ashton Lively
 * Arrow.cs
 * Assignment 1
 * Behavior for arrows. Detects collision with enemies and applies damage.
 */
using UnityEngine;

public class Arrow : MonoBehaviour
{
    /// <summary>
    /// Damage the arrow does
    /// </summary>
    private int damage;

    // Start is called before the first frame update
    void Start()
    {
        SetDamage();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the arrow to the left
        transform.position += Vector3.left * (Time.deltaTime * 3.5f);
    }
    
    void SetDamage()
    {
        // Get type of enemy 
        damage = GameObject.Find("Archer").GetComponent<Enemy>().getDamage();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Swordsman")
        {
            // Set hp down by damage 
            int currentHP = collision.gameObject.GetComponent<Swordsman>().getHitPoints();
            collision.gameObject.GetComponent<Swordsman>().setHitPoints(currentHP - damage);

            // Destroy arrow on hit
            Destroy(gameObject);
        }
    }
}
