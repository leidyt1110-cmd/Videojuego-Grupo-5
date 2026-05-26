using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //  Character that the camera will follow
    public Transform jugador;

    //  Distance between camera and character
    public float offsetX = 3f;

    // Smoothness of movement
    public float suavizado = 5f;

    // Fixed position in Y and Z
    private float posicionY;
    private float posicionZ;

    void Start()
    {
        //  We saved the initial camera position
        posicionY = transform.position.y;
        posicionZ = transform.position.z;
    }

    void LateUpdate()
    {
        float nuevaX = Mathf.Max(transform.position.x, jugador.position.x + offsetX);

        //  We only follow the X-axis
        Vector3 objetivo = new Vector3(
            jugador.position.x + offsetX,
            posicionY,
            posicionZ
        );

        //  Smooth movement
        transform.position = Vector3.Lerp(
            transform.position,
            objetivo,
            suavizado * Time.deltaTime
        );
    }
}
