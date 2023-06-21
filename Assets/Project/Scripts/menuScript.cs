using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class menuScript : MonoBehaviour
{
    public GameObject Menu;

    bool menuIsOpen = false;

    public void PressESC(InputAction.CallbackContext context)
    {
        if (context.started && menuIsOpen == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            startMenu();
        }
        else if (context.started && menuIsOpen == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            endMenu();
        }
    }

    public void startMenu()
    {
        menuIsOpen = true;
        Menu.SetActive(true);
        Time.timeScale = 0;
    }

    public void endMenu()
    {
        menuIsOpen = false;
        Menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void endGame()
    {
        Application.Quit();
    }
}
