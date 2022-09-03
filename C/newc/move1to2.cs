using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move1to2 : MonoBehaviour
{
    public GameObject move;

    public float speed;
    public Transform[] points;
    private int i=0;

    void Update()
    {
        
        if(i==1){
            move.transform.position=Vector2.MoveTowards(move.transform.position,points[0].position,speed*Time.deltaTime);
        }else
        {
            move.transform.position=Vector2.MoveTowards(move.transform.position,points[1].position,speed*Time.deltaTime);
        }

        

    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player")
        {
            i=1;
        }
        if(other.gameObject.tag == "movebox")
        {
            i=1;
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player")
        {
            i=0;
        }
        if(other.gameObject.tag == "movebox")
        {
            i=0;
        }
    }
}
