using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlleShine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.x < 1500)
            transform.localPosition = new Vector3(transform.localPosition.x + 1, transform.localPosition.y, transform.localPosition.z);
        else
            transform.localPosition = new Vector3(-275, transform.localPosition.y, transform.localPosition.z);

    }
}
