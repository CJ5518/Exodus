using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{

    public GameObject goWinText;
    private CanvasGroup cgWinText;

    // Update is called once per frame

    void Start()
    {
        cgWinText = goWinText.GetComponent<CanvasGroup>();
        cgWinText.alpha = 0;
    }
    void Update()
    {
        if (cgWinText.alpha >= 1)
            transform.position = transform.position + new Vector3(0, 1.5f);
        else
            cgWinText.alpha += 0.01f;
    }
}
