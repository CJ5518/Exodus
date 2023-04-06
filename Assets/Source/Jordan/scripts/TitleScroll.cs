using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScroll : MonoBehaviour
{
    // Start is called before the first frame update
    private int iTick;


    // Update is called once per frame
    void Update()
    {

        if (transform.position.x >= 19)
        {
            transform.position = new Vector3(-19, 0, 0);
        }
        if (iTick % 10 == 0)
            transform.position = transform.position + new Vector3(0.01f, 0, 0);


        iTick++;
    }
}
