using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject goBackMenu;
    public GameObject goSettingsMenu;
    public GameObject goFullScreenButton;
    private Image iFullScreenImage;
    void Start()
    {
        goSettingsMenu.SetActive(false);
        iFullScreenImage = goFullScreenButton.GetComponent<Image>();
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

    public void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
        iFullScreenImage.color = new Vector4(255, 255, 255, (!Screen.fullScreen ? 0f : 1f));
    }
}
