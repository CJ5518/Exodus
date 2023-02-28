using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI tmpFPSCounter;
    void Start()
    {
        tmpFPSCounter = GetComponent<TextMeshProUGUI>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 20 == 0)
        {
            float iFramerate = 1 / Time.smoothDeltaTime;
            tmpFPSCounter.SetText("FPS: " + iFramerate);
        }
    }
}
