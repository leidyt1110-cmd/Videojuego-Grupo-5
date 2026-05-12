using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    public int monedasRecolectadas = 0;
    public int vida = 3;
    public int puntos = 0;
    public GameObject panelGameOver;
    public Text textoMonedasFinal;

    public AudioSource audioSource; // El altavoz del jugador
    public AudioClip sonidoSalto;   // El audio de salto
    public AudioClip sonidoMoneda;  // El audio de moneda
    public AudioClip sonidoGameOver; // E audio de Game Over

    private Rigidbody rb;
    private Animator anim;

    private bool isGrounded = true;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        if (audioSource == null) audioSource = GetComponent<AudioSource>();//reproduce el altavoz del jugador 
        Time.timeScale = 1f; //El juego empiece desde el comienzo
    }

    void Update()
    {
        if (Time.timeScale == 0f) return;
        float move = Input.GetAxis("Vertical");

        // Movimiento
        transform.position += Vector3.right * move * speed * Time.deltaTime;

        // Animación
        anim.SetFloat("Speed", Mathf.Abs(move));


        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            anim.SetBool("jump", true);

            if (audioSource && sonidoSalto) audioSource.PlayOneShot(sonidoSalto);//Reproducir sonido salto
        }
        anim.SetBool("jump", !isGrounded);
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("jump", false);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Coin"))
        {
            // Aumentar el contador
            monedasRecolectadas++;
            Debug.Log("Monedas: " + monedasRecolectadas);

            if (audioSource && sonidoMoneda) audioSource.PlayOneShot(sonidoMoneda);//reproducir sonido moneda

            // Destruir la moneda para que desaparezca de la escena
            Destroy(other.gameObject);

        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // CASO 1: Choca con una piedra normal (Pierde puntos)
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            puntos -= 5;
            if (puntos < 0) puntos = 0; // Evita puntos negativos
            Debug.Log("¡Chocaste! Puntos actuales: " + puntos);
        }

        // CASO 2: Cae en piedra de lava (Pierde vida y puntos)
        if (collision.gameObject.CompareTag("Lava"))
        {
            vida -= 1;
            puntos -= 10;
            if (puntos < 0) puntos = 0;

            Debug.Log("¡LAVA! Vida restante: " + vida);

            if (vida <= 0)
            {
                Morir();
            }
            else
            {
                // Teletransporta al jugador un poco atrás para que no muera instantáneamente
                transform.position += Vector3.left * 2;
            }
        }
    }

    void Morir()
    {
        Debug.Log("GAME OVER");

        if (audioSource && sonidoGameOver)
        {
            audioSource.PlayOneShot(sonidoGameOver);
        }

        // Congelar el juego
        Time.timeScale = 0f;

        // Mostrar el panel y las monedas finales
        if (panelGameOver != null)
        {
            panelGameOver.SetActive(true);
        }

        if (textoMonedasFinal != null)
        {
            textoMonedasFinal.text = "Monedas: " + monedasRecolectadas;
        }

        // liberar el cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Reiniciar boton
    public void ReiniciarJuego()
    
    {
        Time.timeScale = 1f;
        Debug.Log("Intentando reiniciar la escena...");
        SceneManager.LoadScene("KJUEGO");
    }

}
// •  Player Controller Implementation: I developed the PlayerMovement script, establishing the core physics-based movement using Unity’s Rigidbody and Vector3 translations.
 This includes precise control over speed and jump forces.
•  Advanced Game Mechanics: I programmed a comprehensive player state system that manages:
Health and Scoring: A logic that tracks lives (vida) and points (puntos),
 with specific penalties for colliding with different obstacles (standard obstacles vs. lava).
Inventory/Collectibles: A trigger-based system for coin collection that updates the UI and triggers audio-visual
 feedback before destroying the object to optimize memory.
•  Animation & Audio Synchronization: I integrated the Animator component to sync movement states (Running, Jumping) with the physics engine. 
Additionally, I implemented a spatial audio system using AudioSource.PlayOneShot to trigger sound effects for jumping, collecting items, and the Game Over state.
•  Game State & UI Logic: I designed the Morir() (Die) function, which manages the "Game Over" transition.
 This involves pausing the game engine (Time.timeScale = 0f), displaying final statistics on the UI, and managing cursor states for menu navigation.
•  Collision Feedback System: I implemented collision detection using OnCollisionEnter and OnCollisionStay to distinguish between "Ground,
" "Obstaculo," and "Lava" tags, ensuring the player interacts correctly with the environment (e.g., resetting the jump state only when grounded).

