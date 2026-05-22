using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Personaje que seguirá la cámara
    public Transform jugador;

    // Distancia entre cámara y personaje
    public float offsetX = 3f;

    // Suavidad del movimiento
    public float suavizado = 5f;

    // Posición fija en Y y Z
    private float posicionY;
    private float posicionZ;

    void Start()
    {
        // Guardamos la posición inicial de la cámara
        posicionY = transform.position.y;
        posicionZ = transform.position.z;
    }

    void LateUpdate()
    {
        float nuevaX = Mathf.Max(transform.position.x, jugador.position.x + offsetX);

        // Solo seguimos el eje X
        Vector3 objetivo = new Vector3(
            jugador.position.x + offsetX,
            posicionY,
            posicionZ
        );

        // Movimiento suave
        transform.position = Vector3.Lerp(
            transform.position,
            objetivo,
            suavizado * Time.deltaTime
        );
    }
}