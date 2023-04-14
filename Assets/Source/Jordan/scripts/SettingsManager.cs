using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject goBackMenu;
    public GameObject goSettingsMenu;
    void Start()
    {
        goSettingsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleSettings()
    {
        goSettingsMenu.SetActive(!goSettingsMenu.activeSelf);
        goBackMenu.SetActive(!goBackMenu.activeSelf);
    }


}
