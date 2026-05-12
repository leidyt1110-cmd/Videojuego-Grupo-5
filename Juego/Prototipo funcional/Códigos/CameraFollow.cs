using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;

    public Vector3 offset;

    void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, transform.position.y, offset.z);

        Vector3 smoothedPosition = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        transform.position = smoothedPosition;
    }
}

Developed the technical description of the main character,
focusing on the 3D free-movement system, including running, 
jumping, and collecting coins. 
Designed the core gameplay loop where players must navigate
falling bricks and avoid lava hazards to reach safety. 
Established the win/loss conditions and the competitive dynamics
between the four players. 
•  Collaborated on the visual organization of game elements using the Miro tool. 
