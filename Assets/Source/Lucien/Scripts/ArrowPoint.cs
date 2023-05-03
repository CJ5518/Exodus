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

        
        
    }
}
