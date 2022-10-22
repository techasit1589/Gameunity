using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Uisetting : MonoBehaviour
{
    public int scene2;
    public GameObject PUi;
    public GameObject text1;
    private Vector2 respawnPoint;

    playmoveTop playMoveTop;
    [SerializeField] GameObject Player;
    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playMoveTop = Player.GetComponent<playmoveTop>();
        Time.timeScale = 1;
        respawnPoint = Player.transform.position;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                //หยุดเกม
                Time.timeScale = 0;
                PUi.SetActive(true);
            }
            else
            {
                //เล่นเกมต่อ
                Time.timeScale = 1;
                PUi.SetActive(false);
            }
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Reset()
    {
        SceneManager.LoadScene(scene2);
        Time.timeScale = 1;
        PUi.SetActive(false);
    }
    public void Resetpoint()
    {
        playMoveTop.transform.position = respawnPoint;
        PUi.SetActive(false);    
        Time.timeScale = 1;       
    }

    public void close()
    {
        text1.SetActive(false);
    }
}
