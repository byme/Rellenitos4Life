using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyScript : MonoBehaviour
{
    [Header("Pathfinding")]
    public Transform target;
    public float activatedDistance = 200.0f;
    public float pathUpdateSecongs = 0.5f;

    [Header("Physics")]
    public float speed = 300.0f;
    public float nextWayPointDistance = 3f;
    public float jumpNodeHeighRequirement = 0.8f;
    public float jumpModifier = 0.3f;
    public float jumpCheckOffset = 0.1f;

    [Header("Custom Behavior")]
    public bool followEnabled= true;
    public bool jumpEnabled = true;
    public bool directionLookEnabled = true;

    private Path path;
    private int currentWayPoint = 0;
    bool isGrounded = false;
    Seeker seeker;
    Rigidbody2D rb;

    public void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, pathUpdateSecongs);
    }

    private void FixedUpdate()
    {
        if (TargetDistance() && followEnabled)
        {
            PathFollow();
        }
    }

    private void UpdatePath() {
        if (TargetDistance() && followEnabled && seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    private void PathFollow() {

        if (path == null) {
            return;
        }

        if (currentWayPoint >= path.vectorPath.Count) {
            return;
        }

        CircleCollider2D collider = GetComponent<CircleCollider2D>();

        //collider sensor
         Vector3 startOffset = transform.position - new Vector3(0f, GetComponent<CircleCollider2D>().bounds.extents.y + jumpCheckOffset);

        isGrounded = Physics2D.Raycast(startOffset,-Vector3.up,0.05f);

      //  RaycastHit2D isGrounded = Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0, Vector2.down, 0.1f, LayerMask.NameToLayer("TileMap"));


        //Direction calculation
        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        //Jump calculation
        if (jumpEnabled && isGrounded) {
            rb.AddForce(Vector2.up * speed * jumpModifier);
        }

        //Generate movement
        rb.AddForce(force);

        //Next point of calculation for path
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);
        if (distance < nextWayPointDistance) {
            currentWayPoint++;
        }

        //Move enemy to -x and +x
     /*   if (rb.velocity.x > 0.05f) {
            transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (rb.velocity.x < -0.05f)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }*/

    }

    private bool TargetDistance() {
        return Vector2.Distance(transform.position, target.transform.position) < activatedDistance;

    }

    private void OnPathComplete(Path p) {
        if (!p.error) {
            path = p;
            currentWayPoint = 0;
        }
    }
}
