using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject panel;
    private bool isPanelOpen = false;
    public PlayerInput playerInput;
    public Player player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Cambia el estado del panel
            isPanelOpen = !isPanelOpen;

            // Activa o desactiva el componente PlayerInput según el estado del panel
            playerInput.enabled = !isPanelOpen;
            player.enabled = !isPanelOpen;
           

            // Activa o desactiva el panel según su estado
            panel.SetActive(isPanelOpen);

            Cursor.lockState = isPanelOpen ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = isPanelOpen;
        }
    }




}
