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
