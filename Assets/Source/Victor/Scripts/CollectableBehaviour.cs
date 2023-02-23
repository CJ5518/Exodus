using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBehaviour : MonoBehaviour
{
    private float amplitude = .1f;
    private float frequency = 2.0f;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float newY = amplitude * Mathf.Sin(Time.time * frequency);
        Vector3 newPosition = new Vector3(startPosition.x, newY + startPosition.y, startPosition.z);

        transform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
