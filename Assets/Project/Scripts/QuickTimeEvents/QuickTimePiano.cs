using UnityEngine;
using UnityEngine.InputSystem;

public class QuickTimePiano : MonoBehaviour
{
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

    Vector3 aPosition;
    Vector3 sPosition;
    Vector3 dPosition;

    bool tp=false;

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
        tp=true;
    }

    private void Update()
    {
        if(pianoTail[tail].transform.position.y<= start.y&& pianoTail[tail].transform.position.y>=finish.y)
        {
            tail++;
            print(tail);
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
            pianoTail[tail].transform.position = new Vector3(spawnPosition.x, positionoftp, 0);
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
