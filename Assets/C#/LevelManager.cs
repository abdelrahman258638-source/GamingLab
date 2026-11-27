using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
   public GameObject Checkpoint; // so we can update the current checkpoint from within Unity

    void Start()
    {
        Checkpoint = null;
    }

    void Update()
    {
    }

    public void RespawnPlayer()
    {
        // Find the player's script (PlayerController, or whatever yours is called)
        // and move the player to the last checkpoint he passed through
        FindObjectOfType<PlayerController>().transform.position = Checkpoint.transform.position;
    }
}
