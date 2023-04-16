using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(0, 1.5f);
        if (transform.position.y > 1500)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
