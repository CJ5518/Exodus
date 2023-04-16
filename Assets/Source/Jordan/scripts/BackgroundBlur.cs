using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundBlur : MonoBehaviour
{
    public bool bBlur;

    private float fTransparency;
    private Image iBackground;


    void Start()
    {
        bBlur = false;
        fTransparency = 0;

        iBackground = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bBlur && fTransparency < 177f)
        {
            fTransparency += 0.01f;
            iBackground.color = new Vector4(iBackground.color.r, iBackground.color.g, iBackground.color.b, fTransparency);

        }
    }
}