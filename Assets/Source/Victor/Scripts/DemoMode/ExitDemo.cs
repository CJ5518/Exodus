using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDemo : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown) {
            ExitDemoMode();
        }
    }


    public void ExitDemoMode() {
        SceneManager.LoadScene("Main Menu");
    }
}
