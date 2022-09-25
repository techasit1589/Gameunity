using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emovement : MonoBehaviour
{
    Vector3 pos, velocity;
    public float speed;
    public int startingPoing;
    public Transform[] points;
    private int i;

    private SpriteRenderer mySpriteRenderer;

    void Awake()
    {
        pos = transform.position;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        transform.position = points[startingPoing].position;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = (transform.position - pos) / Time.deltaTime;
        pos = transform.position;

        if (velocity.x > 1)
        {
            mySpriteRenderer.flipX = true;
        }
        else if (velocity.x < -1)
        {
            mySpriteRenderer.flipX = false;
        }
        
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);

    }
}
