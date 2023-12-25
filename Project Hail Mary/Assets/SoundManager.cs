using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SoundManager : MonoBehaviour
{


    public static SoundManager Instance;

    public AudioSource menuMusicSource;

    public AudioSource clawMovingSource;

    public float default_menu_music_level = 0.5f;

    public float default_claw_sound_level = 0.025f;

    public bool menu_open = false;



    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void muteMenuMusic() {  
        menuMusicSource.volume = 0f;
        menu_open = false;
    }

    public void unmuteMenuMusic() {
        menu_open = true;
        menuMusicSource.volume = default_menu_music_level;
        muteNonMenuMusic();
    }

    // Mutes all audio that is not menu-related
    private void muteNonMenuMusic() {
        clawMovingSource.Pause();
    }



    // Start is called before the first frame update
    void Start()
    {
        clawMovingSource.transform.position = ClawController.claw_position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!menu_open) {
            checkClawSound();
        } else {
            // Menu is open, update music volume
            menuMusicSource.volume = default_menu_music_level;
        }
    }

    private void checkClawSound() {
        if(ClawController.is_moving && SceneManager.GetActiveScene().name == "Dormitory") {
            if(clawMovingSource.isPlaying) {
                clawMovingSource.volume = default_claw_sound_level;
            } else {
                clawMovingSource.Play();
            }
        } else {
            clawMovingSource.Stop();
        }
    }
}
