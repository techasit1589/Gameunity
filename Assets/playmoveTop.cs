using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class playmoveTop : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    private bool canMove =true;

    Vector2 movement;

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
        canMove = true;
    }
    IEnumerator bufftime()
    {
        soundmanager.PlaySound("heal");
        moveSpeed = 10f;
        yield return new WaitForSeconds(10);
        moveSpeed = 5f;
    }
    IEnumerator bufftimezoom()
    {
        soundmanager.PlaySound("heal");
        m_OrthographicCamera.orthographicSize = 6f;
        yield return new WaitForSeconds(20);
        m_OrthographicCamera.orthographicSize = 3f;
    }
}
