using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour {

    public float rotationSpeed = 100f;

    void Update()
    {
        // Rotate the coin on the Y-axis constantly
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}

