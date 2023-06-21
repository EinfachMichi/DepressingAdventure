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
            startMenu();
        }
        else if (context.started && menuIsOpen == true)
        {
            endMenu();
        }
    }

    public void startMenu()
    {
        Menu.SetActive(true);
        Time.timeScale = 0;
    }

    public void endMenu()
    {
        Menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void endGame()
    {
        Application.Quit();
    }
}
