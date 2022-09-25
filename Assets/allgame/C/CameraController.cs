using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public GameObject pointcam;
    public float offset;
    public float offsetSmoothing;
    private Vector3 playerPosition;
    public int i=2;

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(i);
        if (i == 1)
        {
            playerPosition = new Vector3(pointcam.transform.position.x, transform.position.y, transform.position.z); ;
        }
        else if(i == 2)
        {
            playerPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }

        

        if(player.transform.localScale.x > 0f)
        {
            playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
        }
        else
        {
            playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
        }

        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
    }
}