using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour {

    public float rotationSpeed = 100f;

    void Update()
    {
        // Gira la moneda en el eje Y constantemente
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}

