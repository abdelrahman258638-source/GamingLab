using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // Update CurrentCheckpoint in LevelManager to this checkpoint
            FindObjectOfType<LevelManager>().Checkpoint = this.gameObject;
        }
    }
}
