using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                // Exercise #21
using TMPro;                         // Exercise #21
using UnityEngine.SceneManagement;   // Exercise #24

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 3; // Player's current health. When it reaches 0, the player loses a life
    public int lives = 3; // Number of lives left. When lives and health both reach 0, it's game over
    public static int score = 0;
    public static bool hasHeart = false;
    public Image healthBar;                 
    public TextMeshProUGUI scoreUI; 
    public TextMeshProUGUI livesUI; 

    // Timer that counts up toward flickerDuration (used to time each blink)
    private float flickerTime = 0f; 
    // How many seconds pass between each blink (show/hide) of the sprite while immune
    public float flickerDuration = 0.1f;
    // Reference to the player's SpriteRenderer, used to hide/show the sprite for the flicker effect
    private SpriteRenderer sr;
    
    //TODO True while the player is temporarily immune (can't take damage after being hit)
    public bool isImmune = false;
    // Timer that counts up toward immunityDuration while the player is immune
    private float immunityTime = 0f;
    // How many seconds the player stays immune after taking damage
    public float immunityDuration = 1.5f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isImmune == true)
        {
            SpriteFlicker();
            immunityTime = immunityTime + Time.deltaTime;
            if (immunityTime >= immunityDuration)
            {
                isImmune = false;
                sr.enabled = true;
            }
        }

         scoreUI.text = " " + score;
         livesUI.text = " " + lives;
    }

    void SpriteFlicker()
    {
        if (flickerTime < flickerDuration)
        {
            flickerTime = flickerTime + Time.deltaTime;
        }
        else if (flickerTime >= flickerDuration)
        {
            sr.enabled = !(sr.enabled);
            flickerTime = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        if (isImmune == false)
        {
            health = health - damage;
            healthBar.fillAmount = this.health / 3f;
            if (health < 0)
                health = 0;

            if (lives > 0 && health == 0)
            {
                FindObjectOfType<LevelManager>().RespawnPlayer();
                health = 3;
                healthBar.fillAmount = this.health / 3f;
                lives--;
            }
            else if (lives == 0 && health == 0)
            {
                Debug.Log("Gameover");
                Destroy(this.gameObject);
                SceneManager.LoadScene(3);
            }

            Debug.Log("Player Health: " + health.ToString());
            Debug.Log("Player Lives: " + lives.ToString());
        }

        isImmune = true;
        immunityTime = 0f;
    }
}
