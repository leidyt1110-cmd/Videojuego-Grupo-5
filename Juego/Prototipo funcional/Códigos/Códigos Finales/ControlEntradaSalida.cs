using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEntradaSalida : MonoBehaviour {

    //  You can drag a message or an object from the inspector.
    public string mensajeEntrada = "START";
    public string mensajeSalida = "VICTORY";

    private void OnTriggerEnter(Collider other)
    {
        // We verify that it is the player who enters
        if (other.CompareTag("Player"))
        {
            Debug.Log(mensajeEntrada);
            // Here you can activate lights, open doors, or start music.
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //  We verify that it is the Player who leaves
        if (other.CompareTag("Player"))
        {
            Debug.Log(mensajeSalida);
            //  Here you can turn off lights or close doors
        }
    }
}
