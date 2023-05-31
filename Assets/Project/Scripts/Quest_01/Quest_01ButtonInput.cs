using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quest_01ButtonInput : MonoBehaviour
{
    private int round;
    public GameObject[] Button; 

    public void PlayerChoose(int choose)
    {
        //none=0, schere=1, Stein=2, Papier=3
        round++;
        
    }

    private void StartRound()
    {
        Button[0].GetComponent<Button>().interactable = false;
        Button[1].GetComponent<Button>().interactable = false;
        Button[2].GetComponent<Button>().interactable = false;
    }
}
