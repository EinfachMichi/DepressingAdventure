using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quest_01ButtonInput : MonoBehaviour
{
    private int round;
    private int choose; 
    public GameObject[] Button; 

    public void PlayerChoose(int choose)
    {
        //none=0, schere=1, Stein=2, Papier=3
        round++;
        this.choose = choose;
        StartRound();
    }

    private void StartRound()
    {
        for (int i = 0; i < Button.Length; i++)
        {
            Button[i].GetComponent<Button>().interactable = false;
        } 
    }
}
