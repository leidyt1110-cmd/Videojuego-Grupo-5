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
// Implementation of Game State Triggers: I developed the ControlEntradaSalida script to manage the logical transitions within the game levels.
This script uses Unity’s OnTriggerEnter and OnTriggerExit methods to detect when an object tagged as "Player" interacts with specific boundaries.
Event Notification System: I integrated a console-based feedback system using Debug.
Log to signal key game events, such as the "START" message 
upon entering a zone and the "VICTORY" message when a player successfully clears or exits a designated area.
 Collision Logic and Optimization: I implemented tag-based filtering (other.CompareTag("Player"))
 to ensure that environment triggers are only activated by the user,
 preventing bugs caused by other physics objects or enemies interacting with the logic.
System Scalability: The script was designed with public variables
 (mensajeEntrada, mensajeSalida), 
allowing other team members to easily customize zone messages or trigger events like opening doors
, toggling lights, or starting background music directly from the Unity Inspector.//

