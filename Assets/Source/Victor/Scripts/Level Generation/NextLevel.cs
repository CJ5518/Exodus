using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Player")) {
            if(BossSave.boss1Beat == false)
            {
                NextScene();
            }
            
            if(BossSave.boss1Beat == true && BossSave.boss2Beat == false)
            {
                NextNextScene();
            }
        }
    }

    private void NextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void NextNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); 
    }
}
