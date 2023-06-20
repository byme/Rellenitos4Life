using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Aqui va la configuracion de lo que se quiera programar una vez el  jugador colisione con el colectable

            Destroy(gameObject);


        }
    }
}
