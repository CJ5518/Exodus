using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("NEXT SCENE COLLISION");
        if (collider.CompareTag("Player")) {
            NextScene();
        }
    }

    private void NextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
