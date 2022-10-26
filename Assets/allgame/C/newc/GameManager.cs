using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class GameManager : MonoBehaviour
{
    public int scene;
    public GameObject PauseUi;
    public GameObject deadUi;

    PlayerMovement playerMovement;
    [SerializeField] GameObject Player;

    BossHealth bossHealth;
    [SerializeField] GameObject boss;

    //จุดเกิดกล่อง
    private GameObject[] posbox;
    private Vector3[] rebox;

    private GameObject[] arrow;


    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerMovement =Player.GetComponent<PlayerMovement>();
        
        
        
        if(scene == 4)
        {
            bossHealth = boss.GetComponent<BossHealth>();
        }
        

        Time.timeScale = 1;
        posbox = GameObject.FindGameObjectsWithTag("pushable");
        rebox = new Vector3[posbox.Length];
        for (int i = 0; i < posbox.Length; i++)
        {            
            rebox[i] = posbox[i].transform.position;
        }

    }
    void Update()
    {
        if (scene==4)
        {
            arrow = GameObject.FindGameObjectsWithTag("redHP");
        }
        
        //Debug.Log(playerMovement.playerHealth);
        //ตายแล้วหยุดเกม
        if (playerMovement.playerHealth <= 0){
            Time.timeScale = 0;
            deadUi.SetActive(true);          
        }else if(playerMovement.playerHealth <= 3)
        {
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
    }  
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Gamestart()
    {
        SceneManager.LoadScene(scene);
    }
    public void Reset()
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;
        PauseUi.SetActive(false);        
    }
    public void Resetpoint()
    {
        

        if (scene == 4)
        {
            bossHealth.transform.position = new Vector2(60.9f, -3.2f);
            bossHealth.health = 500;
            for (int i = 0; i < arrow.Length; i++)
            {
                Destroy(arrow[i]);
            }
        }
       

        playerMovement.playerHealth = 3;
        playerMovement.transform.position = playerMovement.respawnPoint;
        deadUi.SetActive(false);
        PauseUi.SetActive(false);
        playerMovement.UpdateHealth();
        Time.timeScale = 1;
        for (int i = 0; i < posbox.Length; i++)
        {
            posbox[i].transform.position = rebox[i];
        }
    }
}
