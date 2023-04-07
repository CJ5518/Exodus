using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class DemoModeAI : MonoBehaviour
{
    [Header("Pathfinding")]
    [SerializeField] private Transform target;
    [SerializeField] private float pathUpdateSeconds = 0.5f;

    [Header("Physics")]
    [SerializeField] private float speed = 200f;
    [SerializeField] private float maxSpeed = 1f;
    [SerializeField] private float jumpModifier = 0.3f;
    [SerializeField] private float nextWaypointDistance = 3f;
    [SerializeField] private float jumpCheckOffset = 0.1f;

    [Header("Custum Behavior")]
    [SerializeField] private bool followEnabled = true;
    [SerializeField] private bool jumpEnabled = true;


    private Path path;
    private int currentWaypoint = 0;
    private bool isGrounded = false;
    private bool isOnLeftWall = false;
    private bool isOnRightWall = false;
    private Seeker seeker;
    private Rigidbody2D rb;

    private void Start()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("NavMeshTarget").transform;
        }

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds);
    }

    private void FixedUpdate()
    {
        if (followEnabled)
        {
            PathFollow();
        }
    }

    private void UpdatePath()
    {
        if (followEnabled && seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    private void PathFollow()
    {
        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            return;
        }


        isGrounded = 
            Physics2D.Raycast(
                transform.position + (Vector3.down * (GetComponent<Collider2D>().bounds.extents.y + jumpCheckOffset)), 
                Vector3.down, 
                jumpCheckOffset);

        isOnLeftWall = 
            Physics2D.Raycast(
                transform.position + (Vector3.down * (GetComponent<Collider2D>().bounds.extents.y + jumpCheckOffset)), 
                Vector3.left, 
                GetComponent<Collider2D>().bounds.extents.x + jumpCheckOffset) 
            ||
            Physics2D.Raycast(
                transform.position + (Vector3.left * (GetComponent<Collider2D>().bounds.extents.x + jumpCheckOffset)),
                Vector3.left,
                GetComponent<Collider2D>().bounds.extents.x + jumpCheckOffset);
        isOnRightWall = 
            Physics2D.Raycast(
                transform.position + (Vector3.down * (GetComponent<Collider2D>().bounds.extents.y + jumpCheckOffset)), 
                Vector3.right, 
                GetComponent<Collider2D>().bounds.extents.x + jumpCheckOffset)
            ||
            Physics2D.Raycast(
                transform.position + (Vector3.right * (GetComponent<Collider2D>().bounds.extents.x + jumpCheckOffset)),
                Vector3.right,
                GetComponent<Collider2D>().bounds.extents.x + jumpCheckOffset);

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        force.y = 0;
        rb.AddForce(force);

        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);


        if (jumpEnabled && isGrounded)
        {
            if (!(direction.y < 0.2f))
            {
                rb.AddForce(Vector2.up * speed * jumpModifier);
            }
            if (direction.y > .9f)
            {
                rb.AddForce(Vector2.right * (Random.value - .5f) * (speed / 2));
            }
        }

        if(jumpEnabled && !isGrounded && isOnLeftWall)
        {
            if (direction.y > 0.5f)
            {
                rb.AddForce(((6 * Vector2.up) + Vector2.right).normalized * speed * jumpModifier);
            }
        }

        if (jumpEnabled && !isGrounded && isOnRightWall)
        {
            if (direction.y > 0.5f)
            {
                rb.AddForce((6 * Vector2.up + Vector2.left).normalized * speed * jumpModifier);
            }
        }


        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
}
