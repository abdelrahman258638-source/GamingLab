using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame updatepublic static AudioManager Instance;
    public static AudioManager Instance;
    public AudioSource musicSource; // source that plays background music
    public AudioSource sfxSource;   // source that plays sound effects

    public AudioClip overworldMusic; // background music for level 1
    public AudioClip caveMusic;      // background music for level 2

    public AudioClip[] variousSFX;   // array of sound effect clips to keep things varied

    void Awake()
    {
        // Make sure the entire game only has one Audio Manager throughout
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    void Start()
    {
        // Background music clip is assigned and starts playing
        musicSource.clip = overworldMusic;
        musicSource.Play();
    }

    // Public in case another object needs to call for a specific sound effect
    public void PlayMusicSFX(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.PlayOneShot(clip);
    }

    // Public in case another object needs to call for a specific soundtrack
    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    // Function takes a bunch of sound clips as parameters
    public void PlayRandomSFX(params AudioClip[] clips)
    {
        // Assign the incoming array to our local variable
        variousSFX = clips;

        // Randomly select a clip, then play it
        int index = Random.Range(0, variousSFX.Length);
        sfxSource.PlayOneShot(variousSFX[index]);
    }
}
