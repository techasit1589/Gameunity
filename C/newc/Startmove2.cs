using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startmove2 : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject varGameObject;

    

    void Awake()
    {
        varGameObject = GameObject.FindWithTag("movingplatform2");
    }

    // Update is called once per frame
    
    void OnTriggerEnter2D(Collider2D box)
    {
        if (box.gameObject.tag == "Player")
        {
            varGameObject.GetComponent<MovingPlatform>().enabled = true;
            gameObject.GetComponent<Renderer>().enabled = false;
        }
        if (box.gameObject.tag == "movebox")
        {
            varGameObject.GetComponent<MovingPlatform>().enabled = true;
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
    void OnTriggerExit2D(Collider2D box)
    {
        if (box.gameObject.tag == "Player")
        {
            varGameObject.GetComponent<MovingPlatform>().enabled = false;
            gameObject.GetComponent<Renderer>().enabled = true;
        }
        if (box.gameObject.tag == "movebox")
        {
            varGameObject.GetComponent<MovingPlatform>().enabled = false;
            gameObject.GetComponent<Renderer>().enabled = true;
        }
    }
}
