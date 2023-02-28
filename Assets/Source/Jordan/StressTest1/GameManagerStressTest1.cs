using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerStressTest1 : MonoBehaviour
{

    public GameObject goFPS;
    public GameObject goCanvas;
    private Vector2 vPos;


    void Start()
    {
        vPos = new Vector2(0, 0);
    }
    void Update()
    {
        if (vPos.x < Screen.width)
        {
            if (vPos.x % 10 == 0)
            {
                (Instantiate(goFPS, new Vector3(vPos.x, vPos.y, 0), Quaternion.identity) as GameObject).transform.parent = goCanvas.transform;
            }
            vPos.x++;
        }
        else
        {
            if (vPos.y < Screen.height)
            {
                vPos.y += 25;
                vPos.x = 0;
            }
        }
    }


}
