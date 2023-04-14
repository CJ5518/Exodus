using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject SettingsMenu;

    public GameObject goPauseMenu;
    void Start()
    {
        goPauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            goPauseMenu.SetActive(true);
            Time.timeScale = 0;
        }

    }

    public void ClosePauseMenu()
    {
        goPauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
    