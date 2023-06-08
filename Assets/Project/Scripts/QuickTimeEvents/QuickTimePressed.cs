using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class QuickTimePressed : MonoBehaviour
{
    char pressedLetter;
    char eventLetter;

    int gameRound;

    public TMP_Text QuicktimeLetter;

    private void Awake()
    {
        newQuicktime();
    } 

    public void PressSpace(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            test(pressedLetter = ' ');
        }
    }

    public void PressA(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            test(pressedLetter = 'A');
        }
    }

    public void PressS(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            test(pressedLetter = 'S');
        }
    }

    public void PressD(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            test(pressedLetter = 'D');
        }
    }

    public void PressQ(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            test(pressedLetter = 'Q');
        }
    }

    public void PressW(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            test(pressedLetter = 'W');
        }
    }

    public void PressE(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            test(pressedLetter = 'E');
        }
    }

    void test(char presseLetter)
    {
        //if presseLetter==CurrentLetter / true und eingabe blockieren
        //else / false und eingabe blockieren
        if(presseLetter ==eventLetter)
        {

        }
        else
        {

        }
            newQuicktime();
    }

    void newQuicktime()
    {
        int index = Random.Range(0, 6);

        switch (index)
        {
            case 0:
                eventLetter = 'A';
                break;
            case 1:
                eventLetter = 'S';
                break;
            case 2:
                eventLetter = 'D';
                break;
            case 3:
                eventLetter = 'Q';
                break;
            case 4:
                eventLetter = 'W';
                break;
            case 5:
                eventLetter = 'E';
                break;
        }
        QuicktimeLetter.text= eventLetter.ToString();
    } 
}
