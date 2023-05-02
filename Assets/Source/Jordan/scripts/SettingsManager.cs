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
    public GameObject goBCButton;
    private Image iFullScreenImage;
    private Image iBCImage;

    public bool bDrBCEnabled;
    void Start()
    {
        goSettingsMenu.SetActive(false);
        bDrBCEnabled = false;
        iFullScreenImage = goFullScreenButton.GetComponent<Image>();
        iBCImage = goBCButton.GetComponent<Image>();

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

    public void ToggleBCMode()
    {
        bDrBCEnabled = !bDrBCEnabled;
        iBCImage.color = new Vector4(255, 255, 255, (!bDrBCEnabled ? 1f : 0f));

    }
}
