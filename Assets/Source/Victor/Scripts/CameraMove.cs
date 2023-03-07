using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Rigidbody2D cam;

    [SerializeField]
    private float speed;

    Vector2 direction;

    void Start()
    {
        cam = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //direction = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
        {
            direction.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction.x = 1;
        } 
        if ( !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) )
        {
            direction.x = 0;
        }

        if (Input.GetKey(KeyCode.W))
        {
            direction.y = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction.y = -1;
        } 
        if ( !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) )
        {
            direction.y = 0;
        }

        direction.Normalize();
    }

    void FixedUpdate()
    {
        cam.velocity = direction * speed;
    }
}
