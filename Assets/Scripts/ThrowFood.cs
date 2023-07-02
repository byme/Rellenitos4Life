using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowFood : MonoBehaviour
{

    public GameObject target; // Target (player)

    public GameObject badGuy;

    public float throwingForce = 0.5f;

    




    // Movement speed in units per second.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    private void Start()
    {
        target = GameObject.Find("Player");

        badGuy = GameObject.Find("DonPacho");

        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(transform.position, target.transform.position);

    }

    void Update()
    {

        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(transform.position, target.transform.position, fractionOfJourney);
        /*   Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
           Vector2 direction = target.transform.position - transform.position;
           rb.AddForce(direction*throwingForce);*/

        if (Mathf.Abs(transform.position.x - target.transform.position.x) < 0.20f)
        {
            //lifeBar.DecreaseLife(10.0f * Time.deltaTime);
            target.GetComponent<LifeBar>().DecreaseLife(10.0f);
            Debug.Log("vida bajada");

            Destroy(gameObject);
        }

        if (Mathf.Abs(badGuy.transform.position.x - transform.position.x ) > 2.0f)
        {
            Destroy(gameObject);
        }


    }
}
