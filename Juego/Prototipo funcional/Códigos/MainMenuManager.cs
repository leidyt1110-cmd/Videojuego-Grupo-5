using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Apagar menú
    public GameObject panelDelMenu;

    public void StartGame()
    {
        
        // simplemente desactivamos el menú para poder jugar.
        if (panelDelMenu != null)
        {
            panelDelMenu.SetActive(false);
            Debug.Log("¡El juego ha comenzado!");
        }
        else
        {
          
            Debug.LogWarning("No has asignado el panel del menú en el Inspector");
        }
    }

    public void OpenOptions()
    {
        Debug.Log("Abriendo menú de opciones...");
    }
}
// •  UI Management and Menu Logic: I developed the MainMenuManager script to handle the initial game state. 
I implemented the StartGame method, which manages the transition from the menu to active gameplay by dynamically deactivating UI panels (panelDelMenu.SetActive(false)),
 ensuring a smooth start for the players.
•  Scene Control and Feedback: I integrated a validation system within the UI logic to provide real-time feedback in the Unity console.
 This ensures that the development team is notified if UI components are missing in the Inspector, preventing potential runtime errors.
•  Interactive Event Systems: I programmed the OpenOptions stub to allow for future scalability of the game’s configuration menu,
 establishing a modular structure for the project's interface.
•  Environment Interaction Logic: I implemented the ControlEntradaSalida script, utilizing Unity’s physics engine (OnTriggerEnter / OnTriggerExit) to detect "Player" tags. 
This logic triggers essential game events such as "START" and "VICTORY" messages, which are fundamental for the "Mario Lava Game" progression.
•  Asset Serialization: I managed the metadata (.meta files) and unique identifiers (GUIDs) for all scripts,
 ensuring that the Unity project maintains correct references and component assignments across different development environments.
