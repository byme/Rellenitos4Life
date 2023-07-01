using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    public float pointsToAdd = 5f; // puntos a sumar
    public GameObject playerObject; //referencia al objeto de player (LifeBar )
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //LifeBar lifeBar = collision.GetComponent<LifeBar>();
            LifeBar lifeBar = playerObject.GetComponent<LifeBar>(); // obtiene la referencia al componente LifeBar del objeto player
            if (lifeBar != null)
            { // Aqui va la configuracion de lo que se quiera programar una vez el  jugador colisione con el colectable
              //Accede al componente LifeBar y aumenta los puntos 
                lifeBar.IncreaseLife(pointsToAdd);
            }

            //Destruye objeto Colecionable 
            Destroy(gameObject);


        }
    }
}
