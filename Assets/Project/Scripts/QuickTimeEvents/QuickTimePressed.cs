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

    bool blocked;

    int gameRound=1;
    int lastRoundletter;
    int wrongEvents;

    public int Playerhealth = 100;
    public int Enemyhealth = 100;

    public TMP_Text QuicktimeLetter;
    public TMP_Text PlayerHealthText;
    public TMP_Text EnemyHealthText;

    private void Awake()
    {
        newQuicktime();
        PlayerHealthText.text=Playerhealth.ToString();
        EnemyHealthText.text=Enemyhealth.ToString();
    } 

    public void PressSpace(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            test(pressedLetter = '.');
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
        if (blocked==true)
        {
            return;
        }

        if(presseLetter == eventLetter)
        {
            StartCoroutine(rightLetter());
        }
        else
        {
            StartCoroutine(falseLetter());
        }
            
    }

    IEnumerator rightLetter()
    {
        blocked = true;
        QuicktimeLetter.GetComponent<TMP_Text>().color = Color.green;
        yield return new WaitForSeconds(0.3f);
        QuicktimeLetter.GetComponent<TMP_Text>().color = Color.white;
        print("true");
        blocked = false;
        checkRounds();
    }

    IEnumerator falseLetter()
    {
        blocked = true;
        QuicktimeLetter.GetComponent<TMP_Text>().color = Color.red;
        yield return new WaitForSeconds(0.3f);
        QuicktimeLetter.GetComponent<TMP_Text>().color = Color.white;
        print(false);
        blocked = false;
        wrongEvents++;
        checkRounds();
    }

    void checkRounds()
    {
        if(gameRound<=3)
        {
            newQuicktime();
        }
        else
        {
            eventLetter = ' ';
            QuicktimeLetter.text = eventLetter.ToString();
            blocked = true;
            //play Animation ig
            dmgDealer();
        }
    }

    void newQuicktime()
    {
        
        int index = Random.Range(0, 6);

        if (lastRoundletter == index)
        {
            newQuicktime();
            return;
        }
        lastRoundletter = index;
        gameRound++;

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

    void dmgDealer()
    {
        if (wrongEvents==0)
        {
            Enemyhealth -=20;
            EnemyHealthText.text = Enemyhealth.ToString();
        }
        else
        {
            int enemydmg= wrongEvents * 5;
            Playerhealth-=enemydmg;
            PlayerHealthText.text=Playerhealth.ToString();
            wrongEvents = 0;
        }
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        gameRound = 1;
        blocked = false;
        checkRounds();
    }
}
