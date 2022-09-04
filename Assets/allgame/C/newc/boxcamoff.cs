using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxcamoff : MonoBehaviour
{
    
    
    
    // Start is called before the first frame update
   
    // Update is called once per frame
    private GameObject varGameObject;
    public float X = -3.08f;
    public float Y = -0.01f;
    public float Z = -10f;
    public float offsetSmoothing= 1f;
    public Vector3 camPosition;
    void Awake()
    {
        varGameObject = GameObject.FindWithTag("MainCamera");
    }
    void OnTriggerEnter2D(Collider2D box)
    {
        if (box.gameObject.tag == "Player")
        {
            //Debug.Log("hit");
            varGameObject.GetComponent<CameraController>().enabled = false;
            
            
        }
    }
}
