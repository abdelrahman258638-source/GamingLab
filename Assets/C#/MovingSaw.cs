using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 // Start is called before the first frame update
   public class MovingSaw : EnemyController
{
    public Transform player;

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position,
            maxSpeed * Time.deltaTime);
    }

    // The saw does not flip when it hits the player, only when it hits a wall
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
        }
        else if (other.tag == "Wall")
        {
            Flip();
        }
    }
}
