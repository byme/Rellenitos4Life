using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyMovement : MonoBehaviour
{
    [SerializeField] public float movemeventSpeed = 5.0f;
    Rigidbody2D rb;
    public Transform target;
    Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
       // target = GameObject.Find("Square").transform;

    }

    private void Update()
    {
        if (target)
        {

            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDirection = direction;
        }
    }

    private void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * movemeventSpeed;
        }
    }
}
