using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : EnemyController
{
    // Ghosts pass through walls, so the trigger function is overridden
    // to remove the Flip() call when hitting a wall
     void FixedUpdate()
    {
        // Move left if flipped, right if not
        float direction = sr.flipX ? 1f : -1f;
        transform.Translate(Vector2.right * direction * maxSpeed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
            Flip();
        }
    }
}