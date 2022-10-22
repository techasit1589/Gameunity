using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_Level : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject box2;
    public int scene;

    PlayerMovement playerMovement;

    playmoveTop playMoveTop;

    [SerializeField] GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        
        if (scene == 4)
        {
            playMoveTop = Player.GetComponent<playmoveTop>();
        }
        else
        {
            playerMovement = Player.GetComponent<PlayerMovement>();
        }

    }
    void OnTriggerEnter2D(Collider2D next)
    {
        if(scene == 4)
        {
            if (next.gameObject.tag == "Player")
            {
                
                //Debug.Log("ด่านต่อไป");
                StartCoroutine(NextLevel());
            }
        }
        else
        {
            if (next.gameObject.tag == "Player" && playerMovement.gotreward1)
            {
                playerMovement.gotreward1 = true;
                //Debug.Log("ด่านต่อไป");
                StartCoroutine(NextLevel());
            }
        }
        
    }
    IEnumerator NextLevel()
    {
        //Debug.Log(playerMovement.gotreward1);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
        if(scene == 4)
        {

        }
        else
        {
            if (playerMovement.gotreward1 == true)
            {
                playerMovement.gotreward1 = false;
            }
        }
        
        //Debug.Log(playerMovement.gotreward1);
    }
}
