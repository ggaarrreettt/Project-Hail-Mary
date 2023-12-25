using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public static SettingsMenu Instance;

    public GameObject settingsMenuUI;

    public GameObject pauseMenuUI;

    public bool settingsMenuActive = false;

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
        
    }

    // Takes you from settings menu to the pause menu
    public void returnToPauseMenu() {
        settingsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        settingsMenuActive = false;
    }

    public void changeSensitivity(float sens) {
        MainManager.Instance.mouse_sense = sens;
    }
}
