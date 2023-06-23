using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Food : MonoBehaviour
{
    [SerializeField] GameObject[] foodPrefabs;
    [SerializeField] float secondSpawn;
    [SerializeField] float minTrans;
    [SerializeField] float maxTrans;
    private Rigidbody rb;
    public float spawnInterval = 2f; // Time between each spawn

    private float nextSpawnTime;


      void Start()
      {
        //StartCoroutine(foodSpawn());
        InvokeRepeating("foodSpawn", 0.5f,5.0f);
    }

      void foodSpawn() {

        // while (true) {

        //  var rNumber = Random.Range(minTrans, maxTrans);
        var rNumber = transform.position.y;
        var position = new Vector2(transform.position.x, rNumber);
              GameObject foodObject = Instantiate(foodPrefabs[Random.Range(0, foodPrefabs.Length)]);
              foodObject.transform.position = position;
              

           //   yield return new WaitForSeconds(secondSpawn);
           //   Destroy(gameObject, 3f);
           // }
      }


  /*  private void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            var rNumber = Random.Range(minTrans, maxTrans);
            var position = new Vector2(transform.position.x, rNumber);
            GameObject foodObject = Instantiate(foodPrefabs[Random.Range(0, foodPrefabs.Length)],
                                                  position, Quaternion.identity);
        }
    }*/


}
