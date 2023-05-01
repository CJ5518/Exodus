using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowPoint : MonoBehaviour
{
    [SerializeField]
    private Camera arrowCamera;
    private NextLevel nextLevel;             //this is going to find the level in the scene
    [SerializeField]
    private RectTransform arrowTransform;    //this is the position of the arrow so we can update it later

    private void Awake()
    {
        nextLevel = GameObject.FindAnyObjectByType<NextLevel>();
    }

    private void Update()
    {
        nextLevel = GameObject.FindAnyObjectByType<NextLevel>();
        Vector3 endLocation = nextLevel.transform.position;
        Vector3 currentPosition = Camera.main.transform.position;
        Vector3 playerPosition = GameObject.FindAnyObjectByType<Player>().transform.position;
        playerPosition.z = 0;
        Vector3 direct = (endLocation - playerPosition).normalized;

        float angle = (Mathf.Atan2(direct.y, direct.x) * Mathf.Rad2Deg) % 360;
        arrowTransform.localEulerAngles = new Vector3(0, 0, angle + 270);

        float borderSize = - 100 * 60;
        //make it move around the screen based on where the target is
        Vector3 positionOnScreen = Camera.main.WorldToScreenPoint(nextLevel.transform.position);
        bool offScreen = positionOnScreen.x <= borderSize || positionOnScreen.x >= Screen.width - borderSize || positionOnScreen.y <= borderSize || positionOnScreen.y >= Screen.height - borderSize;

        if(offScreen)
        {
            Vector3 redoneScreenPos = positionOnScreen;
            if(redoneScreenPos.x <= borderSize)
                redoneScreenPos.x = borderSize;
            if(redoneScreenPos.x >= Screen.width - borderSize)
                redoneScreenPos.x = Screen.width - borderSize;
            if(redoneScreenPos.y <= borderSize)
                redoneScreenPos.y = borderSize;
            if(redoneScreenPos.y >= Screen.height - borderSize)
                redoneScreenPos.y = Screen.height - borderSize;

            Vector3 worldLocation = arrowCamera.ScreenToWorldPoint(redoneScreenPos);
            arrowTransform.position = worldLocation;
            arrowTransform.localPosition = new Vector3(arrowTransform.localPosition.x, arrowTransform.localPosition.y, 0); 
        }
    }
}
