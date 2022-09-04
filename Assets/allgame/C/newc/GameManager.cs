using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PauseUi;
    public GameObject deadUi;
    PlayerMovement playerMovement;
    [SerializeField] GameObject Player;
    
    void Awake()
    {
        playerMovement=Player.GetComponent<PlayerMovement>();
        Time.timeScale = 1;
    }
    void Update()
    {
        //Debug.Log(Time.timeScale);
        //ตายแล้วหยุดเกม
        if(playerMovement.healtbar<=0){
            //Debug.Log("deaded");
            StartCoroutine(ExampleCoroutine());
            
        }else{
            //Time.timeScale = 1;
            deadUi.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Escape)){
            if (Time.timeScale == 1)
            {
                //หยุดเกม
                Time.timeScale = 0;
                PauseUi.SetActive(true);
            }
            else
            {
                //เล่นเกมต่อ
                Time.timeScale = 1;
                PauseUi.SetActive(false);
            }
        }
        //ui เวลากด esc
        
    }
    
        
        
    }
    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(0.3f);

        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        Time.timeScale = 0;
        deadUi.SetActive(true);
    }
}
