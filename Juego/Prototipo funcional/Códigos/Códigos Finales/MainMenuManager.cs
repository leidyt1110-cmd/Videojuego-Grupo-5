using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Turn off menu
    public GameObject panelDelMenu;

    public void StartGame()
    {
        
        // We simply deactivated the menu so we could play.
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
