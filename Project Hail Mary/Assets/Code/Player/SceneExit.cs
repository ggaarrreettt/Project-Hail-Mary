using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneExit : MonoBehaviour
{
    public int increment_value = 1;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "LevelChangeCollider") {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + increment_value);
        }
    }
}
