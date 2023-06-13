using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianotailsMove : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] int folge;
    [SerializeField] GameObject startLine;
    [SerializeField] GameObject finishLine;

    public QuickTimePiano Piano;

    Vector3 position;
    Vector3 finish;
    Vector3 finishposition;
    Vector3 start;

    bool overstart = false;
    bool started = true;
    string Nico = "Nico";
    string safesate="safe";

    private void Start()
    {
        finish.y = finishLine.transform.position.y;
        start.y = startLine.transform.position.y;
        finishposition.y =finish.y - 55;
    }
    void Update()
    {
        if(gameObject.transform.position.y > finishposition.y )
        {
            position.y = Time.deltaTime * speed;
            gameObject.transform.Translate(position);
        }

        if (start.y - 50 <= gameObject.transform.position.y&&started && Piano.Reihenfolge == folge)
        {
            print(10);
            overstart = true;
            started = false;
            Piano.Reihenfolge++;
        }
    }
    private void gamestateReset()
    {
        overstart = false;
        started = true;
    }
}
