using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterHand : MonoBehaviour
{
    public Quest_01ButtonInput Q1;

    public void AfterAnimation()
    {
        Q1.StartRound();
    }
}
