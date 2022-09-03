using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown_platform : MonoBehaviour
{
    public bool isup;

    private GameObject player;

    private int hit = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hit == 1)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) && player.GetComponent<PlayerController>().isNotsky)
            {
                transform.parent.GetComponent<Collider2D>().enabled = false;
                hit = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D order)
    {
        if (order.gameObject.CompareTag("player"))
        {
            transform.parent.GetComponent<Collider2D>().enabled = isup;
            player = order.gameObject;
            hit = 1;
        }
    }
}
