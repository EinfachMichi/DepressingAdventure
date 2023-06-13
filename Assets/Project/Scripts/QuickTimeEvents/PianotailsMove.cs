using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianotailsMove : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] GameObject startLine;
    [SerializeField] GameObject finishLine;

    Vector3 position;
    Vector3 finish;
    Vector3 start;

    private void Start()
    {
        finish.y = finishLine.transform.position.y;
        start.y = startLine.transform.position.y;
    }
    void Update()
    {
        if(gameObject.transform.position.y > finish.y-55)
        {
            position.y = Time.deltaTime * speed;
            gameObject.transform.Translate(position);
        }
        
    }
}
