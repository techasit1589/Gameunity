using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitzone : MonoBehaviour
{
    public GameObject box2;
    //public GameObject hitbottom;
    //public float speed = 48f;

    private int test = 0;
    public float speed = 1f;
    // Start is called before the first frame update
    void Update()
    {

        // Debug.Log(box2.transform.position.y);
        // Debug.Log(test);
        if (test == 1)
        {
            if (box2.transform.position.y > -6.48f)
            {
                box2.transform.Translate(Vector2.down * speed * Time.deltaTime);
                gameObject.GetComponent<Renderer>().enabled = false;
            }
        }
        else if (test == 2)
        {
            if (box2.transform.position.y < -3.38f)
            {
                box2.transform.Translate(Vector2.up * speed * Time.deltaTime);
                gameObject.GetComponent<Renderer>().enabled = true;
            }
            else
            {
                test = 0;
            }

        }
    }
    void OnTriggerEnter2D(Collider2D box)
    {
        if (box.gameObject.tag == "Player")
        {
            test = 1;
        }
        if (box.gameObject.tag == "movebox")
        {
            test = 1;
        }
    }
    void OnTriggerExit2D(Collider2D box)
    {
        if (box.gameObject.tag == "Player")
        {
            test = 2;
        }
        if (box.gameObject.tag == "movebox")
        {
            test = 2;
        }

    }
}
