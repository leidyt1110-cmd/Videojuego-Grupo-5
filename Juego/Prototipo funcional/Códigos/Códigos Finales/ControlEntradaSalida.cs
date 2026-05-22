using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEntradaSalida : MonoBehaviour {

    // Puedes arrastrar un mensaje o un objeto desde el inspector
    public string mensajeEntrada = "START";
    public string mensajeSalida = "VICTORY";

    private void OnTriggerEnter(Collider other)
    {
        // Verificamos que sea el Jugador quien entra
        if (other.CompareTag("Player"))
        {
            Debug.Log(mensajeEntrada);
            // Aquí puedes activar luces, abrir puertas o empezar música
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verificamos que sea el Jugador quien sale
        if (other.CompareTag("Player"))
        {
            Debug.Log(mensajeSalida);
            // Aquí puedes apagar luces o cerrar puertas
        }
    }
}
