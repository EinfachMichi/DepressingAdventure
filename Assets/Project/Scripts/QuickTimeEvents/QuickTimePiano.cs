using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class QuickTimePiano : MonoBehaviour
{
    [SerializeField] GameObject[] pianoTail;
    [SerializeField] GameObject startLine;
    [SerializeField] GameObject finishLine;

    char pressedLetter;

    [SerializeField] int speed;

    int tail = 0;

    Vector3 position;
    Vector3 start;

    bool tp=false;

    private void Start()
    {
        tail = 0;
        nextTails();
        start.y = startLine.transform.position.y;
        start.x = startLine.transform.position.x;
        pianoTail[0].transform.position = new Vector3(start.x, start.y, 0);
        tp=true;
    }

    public void PressA(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            check(pressedLetter = 'A');
            print(1);
        }
    }

    public void PressS(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            check(pressedLetter = 'S');
        }
    }

    public void PressD(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            check(pressedLetter = 'D');
        }
    }

    void check(char pressedletter)
    {
        //if(pressedletter==currentletter)
    }

    void nextTails()
    {
        //1 bis 10 
        //1 * 5
        

    }
}
