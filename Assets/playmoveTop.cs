using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class playmoveTop : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    public Text speedtext;
    public Text zoomtext;

    private bool buffspeed=false;
    private bool buffzoom=false;
    
    public GameObject BuffSpeed;
    public GameObject BuffZoom;

    private bool canMove =true;

    Vector2 movement;

    float timeLeft = 10f;
    float timeLeft2 = 20f;

    string displayedtiem;
    string displayedtiem2;
    public Camera m_OrthographicCamera;
    private void Start()
    {
        
    }
    void Update()
    {
       

        
        if (canMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("xY", movement.x);
            animator.SetFloat("yY", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position+ movement*moveSpeed*Time.fixedDeltaTime);
        if (buffspeed)
        {
            
            timeLeft -= Time.deltaTime;
            displayedtiem = timeLeft.ToString("F0");
            speedtext.text = displayedtiem;
            if (timeLeft <= 0)
            {
                timeLeft = 10f;
            }
        }
        if (buffzoom)
        {
            timeLeft2 -= Time.deltaTime;
            displayedtiem2 = timeLeft2.ToString("F0");
            zoomtext.text = displayedtiem2;
            if (timeLeft2 <= 0)
            {
                timeLeft2 = 20f;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //เก็บของรางวัล2
        if (collision.gameObject.tag == "reward2" )
        {
            //gotreward1 = true;
            movement.x = 0;           
            animator.SetBool("Got", true);
            soundmanager.PlaySound("Gotwin");
            Destroy(collision.gameObject);
            canMove = false;
            StartCoroutine(Enew2());
        }
       
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "buff"&& moveSpeed == 5f)
        {
            StartCoroutine(bufftime());
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "zoomout" && m_OrthographicCamera.orthographicSize == 3.0f)
        {
            StartCoroutine(bufftimezoom());
            Destroy(collision.gameObject);
        }
    }
    IEnumerator Enew2()
    {
        yield return new WaitForSeconds(1);
        animator.SetBool("Got", false);
        yield return new WaitForSeconds(1f);
        canMove = true;
    }
    IEnumerator bufftime()
    {
        soundmanager.PlaySound("heal");
        moveSpeed = 10f;
        BuffSpeed.SetActive(true);
        buffspeed=true;
        yield return new WaitForSeconds(10);
        moveSpeed = 5f;
        BuffSpeed.SetActive(false);
        buffspeed = false;
    }
    IEnumerator bufftimezoom()
    {
        soundmanager.PlaySound("heal");
        m_OrthographicCamera.orthographicSize = 6f;
        BuffZoom.SetActive(true);
        buffzoom = true;
        yield return new WaitForSeconds(20);
        m_OrthographicCamera.orthographicSize = 3f;
        BuffZoom.SetActive(false);
        buffzoom = false;
    }
}
