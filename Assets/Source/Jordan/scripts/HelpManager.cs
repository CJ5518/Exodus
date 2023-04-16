using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject goBackMenu;
    public GameObject goHelpMenu;
    void Start()
    {
        goHelpMenu.SetActive(false);
    }

    public void ToggleHelp()
    {
        goHelpMenu.SetActive(!goHelpMenu.activeSelf);
        goBackMenu.SetActive(!goBackMenu.activeSelf);
    }
}
