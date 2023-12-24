using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneExit : MonoBehaviour
{
    public int increment_value = 1;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "LevelChangeColliderUp") {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + increment_value);
        }
        if(other.tag == "LevelChangeColliderDown") {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -increment_value);
        }
    }
}
