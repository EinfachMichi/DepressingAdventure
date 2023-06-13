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
    [SerializeField] GameObject finishLine;
    [SerializeField] GameObject startLine;

    char pressedLetter;

    int tail = 0;
    public int Reihenfolge=0;
    int lastReihenfolge;

    Vector3 position;
    Vector3 start;

    bool tp=false;

    private void Start()
    {
        tail = 0;
        nextTails();
        start.x = startLine.transform.position.x;
        start.y = startLine.transform.position.y;
        pianoTail[0].transform.position = new Vector3(start.x, start.y, 0);
        tp=true;
    }

    private void Update()
    {
        if (Reihenfolge != lastReihenfolge)
        {
            lastReihenfolge = Reihenfolge;
            pianoTail[Reihenfolge].transform.position = new Vector3(start.x, start.y, 0);
        }
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

    public void PressSpace(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

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
