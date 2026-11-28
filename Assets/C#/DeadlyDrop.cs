using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyDrop : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 1;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // Run the RespawnPlayer function in the LevelManager script
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
            FindObjectOfType<LevelManager>().RespawnPlayer();
        }
    }
}
