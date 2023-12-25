using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    public static PauseMenu Instance;

    public static bool game_paused = false;

    public GameObject pauseMenuUI;

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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name != "MainMenu") {
            //Debug.Log("Not in Main Menu");
            if (game_paused && pauseMenuUI != null) {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            } else {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        



            if(Input.GetKeyDown(KeyCode.Escape)) {
                if(game_paused) {
                    Resume();
                } else {
                    Pause();
                }
            }
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        game_paused = false;
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        game_paused = true;
    }

    public void QuitGame() {
        Application.Quit();
    }


}
