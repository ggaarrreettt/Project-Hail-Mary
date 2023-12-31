using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public float start_wait_time = 0.5f;

    public GameObject settingsMenuUI;

    public GameObject mainMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        MainManager.Instance.scene_name_prev = "MainMenu";
        MainManager.Instance.mouse_sense = 500f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        StartCoroutine(gameStartTiming());
        SoundManager.Instance.muteMenuMusic();
    }

    // Waits start_wait_time before beginning game.
    private IEnumerator gameStartTiming() {
        yield return new WaitForSecondsRealtime(start_wait_time);
        SceneManager.LoadScene("Dormitory");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void settingsMenu() {
        SoundManager.Instance.menu_open = true;
        mainMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
        SettingsMenu.Instance.settingsMenuActive = true;
        SettingsMenu.Instance.prev_screen = mainMenuUI;
    }
}
