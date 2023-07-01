using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    public float pointsToAdd = 5f; // puntos a sumar
    public LifeBar lifeBar; //referencia al script LifeBar
    public GameObject particlesEffect;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Aqui va la configuracion de lo que se quiera programar una vez el  jugador colisione con el colectable
            //Accede al componente LifeBar y aumenta los puntos 
            lifeBar.IncreaseLife(pointsToAdd);
            GameObject obj = Instantiate(particlesEffect, transform.position, transform.rotation);
            Destroy(obj, 1f);

            //Destruye objeto Colecionable 
            Destroy(gameObject);


        }
    }
}
