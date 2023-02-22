using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Chase : MonoBehaviour
{
    public GameObject player;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float MAXDISTANCE;

    public Rigidbody2D rigidbody;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
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
