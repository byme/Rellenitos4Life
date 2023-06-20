using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowFood : MonoBehaviour
{

    public GameObject target; // Target (player)
    public float throwingForce = 0.5f;

    private void Start()
    {
        target = GameObject.Find("Square");

    }

    void Update()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        Vector2 direction = target.transform.position - transform.position;
        rb.AddForce(direction*Time.deltaTime*throwingForce);
    }
}
