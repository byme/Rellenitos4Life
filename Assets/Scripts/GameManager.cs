using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Accede al GameManager desde otros scripts
    public CinemachineVirtualCamera cinemachineCamera; //Almacena referencia a la camara 
    public GameObject pauseMenu; // Pausa juego 

    public void pauseButton()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void playButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            pauseButton();
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //Evita que el objeto de la camara virtual se destruya 
        }
        else
        {
            Destroy(gameObject); //Destruye el objeto actual para evitar duplicaciones 
        }
    }


}
