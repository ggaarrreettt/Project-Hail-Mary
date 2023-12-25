using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public float start_wait_time = 0.5f;

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
    }

    // Waits start_wait_time before beginning game.
    private IEnumerator gameStartTiming() {
        yield return new WaitForSecondsRealtime(start_wait_time);
        SceneManager.LoadScene("Dormitory");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
