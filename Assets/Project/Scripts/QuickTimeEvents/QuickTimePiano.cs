using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class QuickTimePiano : MonoBehaviour
{
    public TMP_Text LetterA;
    public TMP_Text LetterS;
    public TMP_Text LetterD;

    public Color standard;

    [SerializeField] GameObject[] pianoTail;

    [SerializeField] GameObject startLine;
    [SerializeField] GameObject finishLine;

    [SerializeField] GameObject A;
    [SerializeField] GameObject S;
    [SerializeField] GameObject D;

    [SerializeField] int minTailHeight;
    [SerializeField] int maxTailHeight;

    char pressedLetter;

    [SerializeField] int speed;

    int tail = 0;

    int firstTail = 0;
    int currentTail;

    int lastSlot=1;

    Vector3 position;
    Vector3 start;
    Vector3 finish;

    [SerializeField] Vector3[] tailscale;

    Vector3 aPosition;
    Vector3 sPosition;
    Vector3 dPosition;

    bool aPress=false;
    bool sPress = false;
    bool dPress = false;

    //reihenfolge der tail,firtsttail,currenttail in den funktionen verfolgen und korregieren!

    private void Start()
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

        nextTails();
    }

    private void Update()
    {
        if (pianoTail[tail].transform.position.y <= start.y - (tailscale[tail].y+0.2) * 10)//(start.y - (tailscale.localscale))
        {
            tailsFunktion();
        }

        if (pianoTail[firstTail].transform.position.y <= finish.y)
        {
            tailscale[firstTail].y = tailscale[tail].y;
            print(firstTail+ ". Tail started");
            currentTail = firstTail;
            firstTail++;
            if (firstTail >= pianoTail.Length)
            {
                firstTail = 0;
            }
        }

        if (pianoTail[currentTail].transform.position.y <= finish.y + (tailscale[currentTail].y + 0.2) * 10)
        {
            tailscale[currentTail].y = tailscale[firstTail].y;
            print(currentTail + ". Tail finished");
            currentTail++;
            if (currentTail >= pianoTail.Length)
            {
                currentTail = 0;
            }
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

            pianoTail[tail].transform.localScale = new Vector3(pianoTail[tail].transform.localScale.x, lenght, tailscale[currentTail].z);

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
            check(pressedLetter = 'A');
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
            check(pressedLetter = 'S');
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
            check(pressedLetter = 'D');
            dPress = true;
            LetterD.GetComponent<TMP_Text>().color = standard;
        }
        else if (context.canceled)
        {
            dPress = false;
            LetterD.GetComponent<TMP_Text>().color = Color.white;
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
