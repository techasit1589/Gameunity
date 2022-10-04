using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movo1to2 : MonoBehaviour
{
    public float speed;
    public Transform[] points;

    private bool move=false;

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
            //Debug.Log("1");
            transform.position = Vector2.MoveTowards(transform.position, points[0].position, speed * Time.deltaTime);
            StartCoroutine(ExampleCoroutine());

        }
        else if (!move && stop)
        {
            //Debug.Log("2");
            transform.position = Vector2.MoveTowards(transform.position, points[1].position, speed * Time.deltaTime);
            StartCoroutine(test());
            
        }
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(3);
        stop = true;
        
        yield return new WaitForSeconds(3);
        move = false;
    }
    IEnumerator test()
    {
        yield return new WaitForSeconds(3);
        stop = false;
        yield return new WaitForSeconds(3);
        move = true;
    }
}
