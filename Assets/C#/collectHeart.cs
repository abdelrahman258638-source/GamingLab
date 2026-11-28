using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectHeart : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip heartSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().lives++;
            PlayerStats.hasHeart = true;
            AudioManager.Instance.PlayMusicSFX(heartSound);
            Debug.Log("Lives: " + FindObjectOfType<PlayerStats>().lives);
            Destroy(gameObject);
        }
    }
}
