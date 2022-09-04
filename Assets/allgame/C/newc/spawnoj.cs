using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnoj : MonoBehaviour
{
    public GameObject objectToSpawn;

    public float timeToSpawn;
    
    private float currentTimeToSpawn;


    void Start()
    {
        //Instantiate(objectToSpawn,transform.position,transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTimeToSpawn>0){
            currentTimeToSpawn -= Time.deltaTime;
        }
        else{
            Spawnject();
            currentTimeToSpawn=timeToSpawn;
        }
    }

    public void Spawnject(){
        Instantiate(objectToSpawn,transform.position,transform.rotation);
    }
}
