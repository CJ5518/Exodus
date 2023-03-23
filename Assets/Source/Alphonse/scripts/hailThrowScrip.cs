using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HailThrowScrip : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;

    public float force;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "boundary")
        {
        
        }
    }
    

    // Update is called once per frame
    void Update() { }
}
