using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxcam : MonoBehaviour
{
    
    
    
    // Start is called before the first frame update
   
    // Update is called once per frame
    private GameObject varGameObject;
    void Awake()
    {
        varGameObject = GameObject.FindWithTag("MainCamera");
    }
    void OnTriggerEnter2D(Collider2D box)
    {
        if (box.gameObject.tag == "Player")
        {
            //Debug.Log("hit");
            varGameObject.GetComponent<CameraController>().enabled = true;
        }
    }
}
