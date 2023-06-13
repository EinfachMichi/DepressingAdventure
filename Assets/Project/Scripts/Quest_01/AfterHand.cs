using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterHand : MonoBehaviour
{
    public Quest_01ButtonInput Q1;

    public void AfterAnimation()
    {
        Q1.StartRound();

        if(Q1.round<4)
        { 
            Q1.Buttons(); 
        }
    }
}
