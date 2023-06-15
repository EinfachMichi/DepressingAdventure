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

    char pressedLetter;

    [SerializeField] int speed;

    int tail = 0;

    Vector3 position;
    Vector3 start;
    Vector3 finish;

    Vector3 tailscale;

    Vector3 aPosition;
    Vector3 sPosition;
    Vector3 dPosition;

    bool aPress=false;
    bool sPress = false;
    bool dPress = false;


    [SerializeField] float positionoftp = 0;

    private void Start()
    {
        tail = 0;
        nextTails();
        start.y = startLine.transform.position.y;
        start.x = startLine.transform.position.x;
        finish.y = finishLine.transform.position.y;

        aPosition.x = A.transform.position.x;
        sPosition.x = S.transform.position.x;
        dPosition.x = D.transform.position.x;

        pianoTail[0].transform.position = new Vector3(start.x, positionoftp, 0);

        tailscale = pianoTail[0].transform.localScale;

        pianoTail[0].transform.localScale = new Vector3(tailscale.x, tailscale.y, tailscale.z);
    }

    private void Update()
    {
        if(pianoTail[tail].transform.position.y<= start.y-50&& pianoTail[tail].transform.position.y>=finish.y)//(start.y - (lasttail.scale))
        {
            tail++;
            if (tail == pianoTail.Length)
            {
                tail = 0;
            }

            int index = Random.Range(0, 3);
            Vector3 spawnPosition = new Vector3(0, 0, 0);
            switch (index)
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

    public void PressA(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            check(pressedLetter = 'A');
            print(1);
            aPress = true;
            LetterA.GetComponent<TMP_Text>().color = standard;
        }
        else if (context.canceled)
        {
            print(0);
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
            print(0);
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
            print(0);
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
