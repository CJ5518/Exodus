using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


public class ButtonPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public bool buttonPressed;
    private Vector3 vTextBasePos;
    private GameObject goText;

    void Start()
    {
        goText = transform.GetChild(0).gameObject;
        vTextBasePos = goText.transform.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }


    void Update()
    {
        if (buttonPressed)
            goText.transform.position = vTextBasePos + new Vector3(0, -10, 0);
        else
            goText.transform.position = vTextBasePos;
    }
}

