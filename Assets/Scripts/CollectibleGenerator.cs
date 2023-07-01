using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleGenerator : MonoBehaviour
{
    public GameObject[] collectiblePrefabs;
    public int numObjects = 10; //Cantidad de objetos 
    public float rangeX = 5f;
    public float rangeY = 5f;
    public GameObject playerObject; // Referencia al objeto player (LifeBarPrefab)

    private void Start()
    {
        for (int i = 0; i < numObjects; i++)
        {
            Vector2 posicionAleatoria = new Vector2(Random.Range(-rangeX, rangeX), Random.Range(-rangeY, rangeY));
            GameObject collectiblePrefab = collectiblePrefabs[Random.Range(0, collectiblePrefabs.Length)];
            Instantiate(collectiblePrefab, posicionAleatoria, Quaternion.identity, transform).GetComponent<Collectible>().playerObject = playerObject;
        }
    }

   
   
}
