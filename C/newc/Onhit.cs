using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onhit : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject varGameObject;
    public GameObject move;

    public float speed;
    public Transform[] points;
    private int i=0;

    void Update()
    {
        
        if(i==1){
            move.transform.position=Vector2.MoveTowards(move.transform.position,points[0].position,speed*Time.deltaTime);
        }
        

    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player")
        {
            varGameObject.SetActive(true);
            i=1;
            
            
        }
    }
}
