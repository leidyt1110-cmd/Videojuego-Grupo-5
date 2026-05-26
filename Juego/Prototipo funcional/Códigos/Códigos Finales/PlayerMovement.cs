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

    public AudioSource audioSource; // The player's speaker
    public AudioClip sonidoSalto;   // The jump audio
    public AudioClip sonidoMoneda;  // The currency audio
    public AudioClip sonidoGameOver; // Game Over audio

    private Rigidbody rb;
    private Animator anim;

    private bool isGrounded = true;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        if (audioSource == null) audioSource = GetComponent<AudioSource>();//The player's speaker plays the
        Time.timeScale = 1f; //The game starts from the beginning
    }

    void Update()
    {
        if (Time.timeScale == 0f) return;
        float move = Input.GetAxis("Vertical");

        // Motion
        transform.position += Vector3.right * move * speed * Time.deltaTime;

        // Animation
        anim.SetFloat("Speed", Mathf.Abs(move));


        // Leap
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            anim.SetBool("jump", true);

            if (audioSource && sonidoSalto) audioSource.PlayOneShot(sonidoSalto);// Play skip sound
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
            // Increase counter
            monedasRecolectadas++;
            Debug.Log("Monedas: " + monedasRecolectadas);

            if (audioSource && sonidoMoneda) audioSource.PlayOneShot(sonidoMoneda);// play sound coin

            // Destroy the coin so that it disappears from the scene
            Destroy(other.gameObject);

        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // CASE 1: Collides with a normal rock (Loses points)
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            puntos -= 5;
            if (puntos < 0) puntos = 0; // Avoid negative points
            Debug.Log("¡Chocaste! Puntos actuales: " + puntos);
        }

        // CASE 2: Falls into lava rock (Loses life and points)
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
                // Teleports the player back a little so they don't die instantly
                transform.position += Vector3.left * 1;
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

        // Freeze the game
        Time.timeScale = 0f;

        // Show the panel and the final coins
        if (panelGameOver != null)
        {
            panelGameOver.SetActive(true);
        }

        if (textoMonedasFinal != null)
        {
            textoMonedasFinal.text = "Monedas: " + monedasRecolectadas;
        }

        // release the cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    //Reset button function
    public void ReiniciarJuego()
    {
        Time.timeScale = 1f;
        DynamicGI.UpdateEnvironment();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //Exit button function
    public void SalirdelJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

}
