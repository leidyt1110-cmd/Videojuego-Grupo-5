using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controladorvictoria : MonoBehaviour
{
    // victory panel
    public GameObject panelVictoria;

    //  Text coins
    public Text textoMonedasFinal;

    //  Reference to the player
    private PlayerMovement jugador;

    private void Start()
    {
        //  Turn off panel on startup
        if (panelVictoria != null)
        {
            panelVictoria.SetActive(false);
        }
    }

    //  When the player reaches the goal
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Get the PlayerMovement script
            jugador = other.GetComponent<PlayerMovement>();

            // Activate victory
            ActivarVictoria();
        }
    }

    void ActivarVictoria()
    {
        // Show panel
        panelVictoria.SetActive(true);

        // Show real coins
        if (textoMonedasFinal != null && jugador != null)
        {
            textoMonedasFinal.text =
                "Monedas: " + jugador.monedasRecolectadas;
        }

        // Pause game
        Time.timeScale = 0f;

        // Show cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    //Restart game button
    public void ReiniciarJuego()
    {
        Time.timeScale = 1f;
        DynamicGI.UpdateEnvironment();

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    // exit button
    public void SalirdelJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
