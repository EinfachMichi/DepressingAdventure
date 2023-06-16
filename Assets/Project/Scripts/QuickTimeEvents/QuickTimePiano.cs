using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class QuickTimePiano : MonoBehaviour
{
    public TMP_Text LetterA;
    public TMP_Text LetterS;
    public TMP_Text LetterD;

    public TMP_Text PointsText;

    public Color standard;

    [SerializeField] GameObject[] pianoTail;

    [SerializeField] GameObject startLine;
    [SerializeField] GameObject finishLine;

    [SerializeField] GameObject A;
    [SerializeField] GameObject S;
    [SerializeField] GameObject D;

    [SerializeField] int minTailHeight;
    [SerializeField] int maxTailHeight;

    [SerializeField] int abstand;

    [SerializeField] float score;
    [SerializeField] float pointsPerSec;

    [SerializeField] float timer;

    char pressedLetter;

    [SerializeField] int tail = 0;

    [SerializeField] int firstTail = 0;
    [SerializeField] int TailLast;

    int lastSlot=1;

    Vector3 position;
    Vector3 start;
    Vector3 finish;

    [SerializeField] Vector3[] tailscale;

    Vector3 aPosition;
    Vector3 sPosition;
    Vector3 dPosition;

    [SerializeField] bool aPress=false;
    [SerializeField] bool sPress = false;
    [SerializeField] bool dPress = false;

    [SerializeField] bool tailIsA = false;
    [SerializeField] bool tailIsS = false;
    [SerializeField] bool tailIsD = false;

    bool gameEnd = false;

    bool tailPlayes = true;

    //reihenfolge der tail,firtsttail,currenttail in den funktionen verfolgen und korregieren!

    private void Awake()
    {
        tail = 0;
        
        start.y = startLine.transform.position.y;
        start.x = startLine.transform.position.x;
        finish.y = finishLine.transform.position.y;

        aPosition.x = A.transform.position.x;
        sPosition.x = S.transform.position.x;
        dPosition.x = D.transform.position.x;

        pianoTail[0].transform.position = new Vector3(start.x, start.y, 0);

        tailscale[tail] = pianoTail[0].transform.localScale;

        int lenght = Random.Range(minTailHeight, maxTailHeight);
        tailscale[tail].y = lenght;
        tailscale[firstTail].y = tailscale[tail].y;

        pianoTail[0].transform.localScale = new Vector3(tailscale[tail].x, tailscale[tail].y, tailscale[tail].z);
    }

    private void Update()
    {
        PointsText.text = score.ToString("0,0");


        if (tailIsA && aPress)
        {
            score = score+Time.deltaTime * pointsPerSec;
        }

        if (timer > 0)
        {
            timer = timer - Time.deltaTime;
        }
        else
        {
            gameEnd = true;
        }

        if (tailIsS && sPress)
        {
            score = score + Time.deltaTime * pointsPerSec;
        }

        if(tailIsD && dPress)
        {
            score = score+Time.deltaTime * pointsPerSec;
        }

        if ((tailIsA==true && (aPress==false||sPress==true||dPress==true))|| (tailIsS == true && (sPress == false || aPress == true || dPress == true)) || (tailIsD == true && (dPress == false || aPress == true || sPress == true)))
        {
            score -= Time.deltaTime * pointsPerSec;
        }

        if ((aPress == true) && (sPress == true || dPress == true))
        {
            score -= Time.deltaTime * pointsPerSec;
            print(1);
        }

        if((sPress == true && dPress == true))
        {
            score -= Time.deltaTime * pointsPerSec;
            print(2);
        }



        if (pianoTail[tail].transform.position.y <= start.y - (tailscale[tail].y+0.2) * abstand&&gameEnd==false)//(start.y - (tailscale.localscale))
        {
            tailsFunktion();
        }

        if (pianoTail[firstTail].transform.position.y <= finish.y)
        {
            //print(firstTail+ ". Tail started");

            firstTail++;
            if (firstTail >= pianoTail.Length)
            {
                firstTail = 0;
            }
            tailPlayes = true;
            if (pianoTail[TailLast].transform.position.x == aPosition.x)
            {
                tailIsA = true;
            }
            if (pianoTail[TailLast].transform.position.x == sPosition.x)
            {
                tailIsS = true;
            }
            if (pianoTail[TailLast].transform.position.x == dPosition.x)
            {
                tailIsD = true;
            }
        }

        if (pianoTail[TailLast].transform.position.y <= finish.y - pianoTail[TailLast].transform.localScale.y*10 )
        {
            //print(TailLast + ". Tail finished");
            TailLast++;
            if (TailLast >= pianoTail.Length)
            {
                TailLast = 0;
            }
            tailPlayes = false;

            tailIsA = false;
            tailIsS = false;
            tailIsD = false;

            TailLast = firstTail;
        }
    }

    void tailsFunktion()
    {
        {
            int slotIndex = Random.Range(0, 3);
            if (lastSlot == slotIndex)
            {
                tailsFunktion();
                return;
            }
            tail++;
            if (tail == pianoTail.Length)
            {
                tail = 0;
            }

            int lenght = Random.Range(minTailHeight, maxTailHeight);
            tailscale[tail].y = lenght;
            tailscale[firstTail].y = tailscale[tail].y;

            pianoTail[tail].transform.localScale = new Vector3(pianoTail[tail].transform.localScale.x, lenght, tailscale[TailLast].z);

            lastSlot = slotIndex;
            Vector3 spawnPosition = new Vector3(0, 0, 0);
            switch (slotIndex)
            {
                case 0:
                    spawnPosition.x = aPosition.x;
                    break;
                case 1:
                    spawnPosition.x = sPosition.x;
                    break;
                case 2:
                    spawnPosition.x = dPosition.x;
                    break;
            }
            pianoTail[tail].transform.position = new Vector3(spawnPosition.x, start.y, 0);
        }
    }

    void lastTail()
    {

    }

    public void PressA(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            aPress = true;
            LetterA.GetComponent<TMP_Text>().color = standard;
        }
        else if (context.canceled)
        {
            aPress = false;
            LetterA.GetComponent<TMP_Text>().color = Color.white;
        }
    }


    public void PressS(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            sPress = true;
            LetterS.GetComponent<TMP_Text>().color = standard;
        }
        else if (context.canceled)
        {
            sPress = false;
            LetterS.GetComponent<TMP_Text>().color = Color.white;
        }
    }


    public void PressD(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            dPress = true;
            LetterD.GetComponent<TMP_Text>().color = standard;
        }
        else if (context.canceled)
        {
            dPress = false;
            LetterD.GetComponent<TMP_Text>().color = Color.white;
        }
    }
}
