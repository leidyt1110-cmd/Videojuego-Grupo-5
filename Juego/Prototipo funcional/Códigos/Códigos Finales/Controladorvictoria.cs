using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controladorvictoria : MonoBehaviour
{
    // Panel victoria
    public GameObject panelVictoria;

    // Texto monedas
    public Text textoMonedasFinal;

    // Referencia al jugador
    private PlayerMovement jugador;

    private void Start()
    {
        // Apagar panel al iniciar
        if (panelVictoria != null)
        {
            panelVictoria.SetActive(false);
        }
    }

    // Cuando el jugador llega a la meta
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Obtener el script PlayerMovement
            jugador = other.GetComponent<PlayerMovement>();

            // Activar victoria
            ActivarVictoria();
        }
    }

    void ActivarVictoria()
    {
        // Mostrar panel
        panelVictoria.SetActive(true);

        // Mostrar monedas reales
        if (textoMonedasFinal != null && jugador != null)
        {
            textoMonedasFinal.text =
                "Monedas: " + jugador.monedasRecolectadas;
        }

        // Pausar juego
        Time.timeScale = 0f;

        // Mostrar cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    //Botón reiniciar juego
    public void ReiniciarJuego()
    {
        Time.timeScale = 1f;
        DynamicGI.UpdateEnvironment();

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    // Botón salir
    public void SalirdelJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}