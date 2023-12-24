using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStorageMovement : MonoBehaviour
{

    public float player_speed = 1.5f;

    private bool go_up = false;

    public float y_level = -2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(go_up) {
            if(Input.GetKeyDown(KeyCode.E)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

        inputMovement();
        transform.localPosition = new Vector3(transform.localPosition.x, y_level, transform.localPosition.z);
    }
    private void inputMovement() {

        float x  = Input.GetAxis("Horizontal");
        float z  = Input.GetAxis("Vertical");
        


        // Update position
        Vector3 movement = new Vector3(x, 0, z);
        transform.Translate(movement * player_speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "LevelChangeColliderUp") {
            go_up = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "LevelChangeColliderUp") {
            go_up = false;
        }
    }
}
