using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popup : MonoBehaviour
{
    private int test = 0;
    public Text textpopup;
    // Update is called once per frame
    void Update()
    {
        if (test==1){
            textpopup.gameObject.SetActive(true);
        }
        else{
            textpopup.gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D box)
    {
        if (box.gameObject.tag == "Player")
        {
            test = 1;
        }
    }
    void OnTriggerExit2D(Collider2D box)
    {
        if (box.gameObject.tag == "Player")
        {
            test = 2;
        }
    }
}
