using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Chase : MonoBehaviour
{
    private GameObject player;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float MAXDISTANCE;

    private Rigidbody2D rigidbody;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance < MAXDISTANCE){
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}
