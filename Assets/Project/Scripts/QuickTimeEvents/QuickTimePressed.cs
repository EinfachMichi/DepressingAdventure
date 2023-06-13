using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuickTimePressed : MonoBehaviour
{
    char Letter;
    private void Awake()
    {
        
    }

    public void PressA(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            test(Letter = 'A');
        }
    }

    public void PressS(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            test(Letter = 'S');
        }
    }

    public void PressD(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            test(Letter = 'D');
        }
    }

    public void PressQ(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            test(Letter = 'Q');
        }
    }

    public void PressW(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            test(Letter = 'W');
        }
    }

    public void PressE(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            test(Letter = 'E');
        }
    }

    void test(char presseLetter)
    {
        //if presseLetter==CurrentLetter / true und eingabe blockieren
        //else / false und eingabe blockieren
    }
}
