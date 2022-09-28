using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movo1to2 : MonoBehaviour
{
    public float speed;
    public Transform[] points;

    private bool move;

    private bool stop;

    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(ExampleCoroutine());
    }
    // Update is called once per frame
    void Update()
    {
        if (move && !stop)
        {
            
            StartCoroutine(ExampleCoroutine());
            transform.position = Vector2.MoveTowards(transform.position, points[0].position, speed * Time.deltaTime);
        }
        else if(!move && stop)
        {
            
            StartCoroutine(test());
            transform.position = Vector2.MoveTowards(transform.position, points[1].position, speed * Time.deltaTime);
        }
    }
    IEnumerator ExampleCoroutine()
    {
        stop = true;
        move = false;
        yield return new WaitForSeconds(5);
        
    }
    IEnumerator test()
    {
        move = true;
        stop = false;
        yield return new WaitForSeconds(5);
        
    }
}
