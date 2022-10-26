using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ttt : MonoBehaviour
{
    float pos;
    bool test;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
       

        if (transform.position.y < pos-0.2f)
        {
            

            test =true;
        }
        else if(transform.position.y > pos+0.2f)
        {
            
            test =false;
        }

        if (test == true)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.1f * Time.deltaTime );
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.1f * Time.deltaTime );
        }
        
    }
}
