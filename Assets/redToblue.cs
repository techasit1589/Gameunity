using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redToblue : MonoBehaviour
{
    PlayerMovement playerMovement;
    [SerializeField] GameObject Player;

    private GameObject[] Redbutton;
    private GameObject[] Bluebutton;
    void Start()
    {
        playerMovement = Player.GetComponent<PlayerMovement>();
        Redbutton = GameObject.FindGameObjectsWithTag("redbutton");
        Bluebutton = GameObject.FindGameObjectsWithTag("bluebutton");
        //Debug.Log(Redbutton.Length);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(playerMovement.redOrblue);
        if (playerMovement.redOrblue == 1)
        {
            for (int i = 0; i < Redbutton.Length; i++)
            {
                Redbutton[i].gameObject.SetActive(false);
                Bluebutton[i].gameObject.SetActive(true);
            }
            
        }
        else if (playerMovement.redOrblue == 2)
        {
            for (int i = 0; i < Bluebutton.Length; i++)
            {
                Redbutton[i].gameObject.SetActive(true);
                Bluebutton[i].gameObject.SetActive(false);
                
            }
            
        }


    }
}
