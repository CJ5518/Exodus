using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDirection : MonoBehaviour
{
    public Transform player;
    public GameObject Boss;
    public GameObject bossCanvasFinder;
    public RectTransform bossHealthCanvas;

    public bool isFlipped = false;

    void Start() 
    {
        Boss = GameObject.FindGameObjectWithTag("Boss");
        bossCanvasFinder = GameObject.FindGameObjectWithTag("bossHealthCanvas");
        bossHealthCanvas = bossCanvasFinder.GetComponent<RectTransform>();
    }

    void Update()
    {
        Flipped();
    }
    public void Flipped()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if(transform.position.x > player.position.x && isFlipped)
        {
            //transform.localScale = flipped;
            Boss.transform.Rotate(0f, 180f, 0f);

            isFlipped = false;
        }
        else if(transform.position.x < player.position.x && !isFlipped)
        {
            //transform.localScale = flipped;
            Boss.transform.Rotate(0f, 180f, 0f);

            isFlipped = true;
            healthCanvasDir();
        }
    }

    public void healthCanvasDir()
    {
        bossHealthCanvas.Rotate(0f, 180f, 0f);
    }
}
