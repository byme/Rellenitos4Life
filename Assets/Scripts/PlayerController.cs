
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    public LifeBar lifeBar; // referencia de la barra de vida 
    public float decreseRate = 1f; // Velocidad en la que disminuye la barra de vida 
    private bool isRunning = false;
    private bool isJumping = false;
    private Rigidbody2D rb;
    private Vector2 startPosition; // almacena la posicion de inicio del jugador 
    private Cinemachine.CinemachineVirtualCamera cinemachineCamera;

    private void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        DontDestroyOnLoad(gameObject);
       
    }

    private void FixedUpdate()
    {   //El jugador inicia a correr cuando se le da click a cualquier parte de la pantalla 
        if (Input.GetMouseButtonDown(0))
        {
            isRunning = true;
        }

        if (isRunning)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        //Salto del jugador 
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;

        }

        DecreaseLifeOverTime();
    }

    void DecreaseLifeOverTime()
    {
        lifeBar.DecreaseLife(decreseRate * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {       //Cambio de escena
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex);
                transform.position =  startPosition   ; // Restablece la posición del jugador al inicio del nuevo nivel
            }

           
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        if (scene.buildIndex > 0)
        {
            startPosition = transform.position; // Actualiza la posición de inicio del jugador al cargar un nuevo nivel
            
            //Camara sigue al Player en cada nivel 
            CinemachineVirtualCamera[] virtualCameras = FindObjectsOfType<CinemachineVirtualCamera>();
            foreach (CinemachineVirtualCamera virtualCamera in virtualCameras)
            {
                virtualCamera.Follow = transform;
            }
        }

    }
}

