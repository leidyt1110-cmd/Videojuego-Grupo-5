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
// •  Dynamic Object Animation: I developed the RotateCoin script to handle the visual behavior of collectible items. By implementing constant rotation logic using transform.
Rotate and Time.deltaTime, I ensured smooth, frame-rate-independent animations that improve the game's visual polish and help players identify interactive assets.
•  Core Gameplay Systems: I programmed the PlayerMovement controller, integrating a robust physics-based system for movement and jumping,
 along with a complex state machine for health (vida), scoring (puntos), and coin collection.
•  Event-Driven Environment: I implemented the ControlEntradaSalida system to trigger critical game messages ("START" / "VICTORY") 
based on player proximity, ensuring a clear flow of progression throughout the level.
•  User Interface Control: I designed and implemented the MainMenuManager, 
providing the logic necessary to transition between the main menu and the active game scene, including the management of the 
"Game Over" state and final statistics display.
•  Project Integrity and Serialization: I managed the metadata structure
 (.meta files) for all scripts, maintaining consistent 
GUIDs and ensuring that all components and their references remained stable within the Unity project architecture.

