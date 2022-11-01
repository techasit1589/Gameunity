using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class onplayerhit : MonoBehaviour
{
    public GameObject block;
    public GameObject boss;
    //cam
    CameraController cameraController;
    [SerializeField] GameObject Ccam;

    PlayerMovement playerMovement;
    [SerializeField] GameObject Player;

    volumTest volumTestt;
    [SerializeField] GameObject volumm;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = Player.GetComponent<PlayerMovement>();

        volumm = GameObject.FindGameObjectWithTag("Cmusic");
        volumTestt = volumm.GetComponent<volumTest>();

        cameraController = Ccam.GetComponent<CameraController>();
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            volumTestt.scene = 5;
            //musicBG.PlaySound("Fboss");
            StartCoroutine(wait());
            block.SetActive(true);
            boss.SetActive(true);   
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //musicBG.PlaySound("BG");
            cameraController.i = 2;
            block.SetActive(false);
            //boss.SetActive(false);
        }
    }
    IEnumerator wait()
    {
        playerMovement.horizontal = 0;
        playerMovement.canMove = false;
        cameraController.i = 3;
        yield return new WaitForSeconds(3);
        cameraController.i = 1;
        playerMovement.canMove = true;
    }
}
