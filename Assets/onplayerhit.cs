using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class onplayerhit : MonoBehaviour
{
    //cam
    CameraController cameraController;
    [SerializeField] GameObject Ccam;

    private void Awake()
    {
        cameraController = Ccam.GetComponent<CameraController>();
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            cameraController.i = 1;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            cameraController.i = 2;
        }
    }
}
