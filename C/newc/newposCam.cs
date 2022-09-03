using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newposCam : MonoBehaviour
{
    public GameObject cam;
    private Vector3 camPosition;
    public float x;
    public float y;
    public float z;
    

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D box)
    {
        if (box.gameObject.tag == "Player")
        {
            camPosition = new Vector3(x,y,z);
            cam.transform.position = camPosition;
        }
    }
    // void OnTriggerExit2D(Collider2D box)
    // {
    //     if (box.gameObject.tag == "Player")
    //     {
    //         i=0;
    //         camPosition = new Vector3(-14.57f, 2.04f,-10f);
    //         cam.transform.position = camPosition;
    //     }
    // }
}
