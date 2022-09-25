using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    //ปุ่มแดงน้ำเงิน
    public int redOrblue= 1;
      
    //จุดเกิด
    public Vector3 respawnPoint;

    //เสียง
    AudioSource audioSource;
    //หัวใจเลือด
    public int playerHealth;
    [SerializeField] private Image[] hearts;
    //วิ่ง
    //private bool isMoving;
    Animator animator;
    private float horizontal;
    private float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;

    //พุ่ง
    private bool canDash = true;
    private bool isDashing;
    public float dashingPower = 10f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    //ดันกล่อง
    public float distance = 1f;
    public LayerMask boxMask;
    GameObject box;
    //ขึ้นบรรได
    public LayerMask whatIsLadder;
    private bool isClimbing;
    private float inputVertical;
    //โดนดาเมจ
    private bool damaged=true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;

    
    void Start()
    {

        

        animator = this.gameObject.GetComponent<Animator>();   
        animator.SetBool("Death", false);
        UpdateHealth();
        audioSource = GetComponent<AudioSource>();
        respawnPoint=transform.position;
        
    }

    private void Update()
    {
        
        //พุ่ง
        if (isDashing)
        {
            return;
        }
        //ดันกล่อง
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);
        //ท่าดันกล่อง
        if (hit.collider != null && hit.collider.gameObject.tag == "pushable")
        {
            animator.SetBool("pushed", true);
        }
        else
        {
            animator.SetBool("pushed", false);
        }
        //เดิน
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        //if (rb.velocity.x != 0)
        //{
        //    isMoving = true;
        //}
        //else
        //{
        //    isMoving = false;
        //}
        //if (isMoving && IsGrounded())
        //{
        //    if (!audioSource.isPlaying)
        //    {
        //        audioSource.Play();
        //    }
        //    else
        //    {
        //        audioSource.Stop();
        //    }
            
        //    //soundmanager.PlaySound("walk");
        //}

        //กระโดด
        animator.SetFloat("yVelocity", rb.velocity.y);
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            soundmanager.PlaySound("jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (IsGrounded())
        {
            animator.SetBool("Grounded", true);
            animator.SetBool("Jump", false);
        }
        else if (!IsGrounded())
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Grounded", false);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && IsGrounded())
        {
            StartCoroutine(Dash());
        }
        //สลับหน้า
        Flip();
        //ขึ้นบรรได
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);
        if (hitInfo.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                isClimbing = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                isClimbing = false;
            }
        }
        if (isClimbing == true && hitInfo.collider != null)
        {
            animator.SetBool("Climb", true);
            inputVertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(0.0f, inputVertical * speed);
            rb.gravityScale = 0;
        }
        else
        {
            animator.SetBool("Climb", false);
            rb.gravityScale = 4;
        }
        
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    //ยืนบนพื้น
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    //กลับตัวละคร
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    //พุ่ง
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
    //ชนสิ่งต่างๆ
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "checkpoint")
        {
            respawnPoint = transform.position;

        }
        if (other.gameObject.tag == "fallpoint")
        {
            transform.position = respawnPoint;
        }

        if (other.gameObject.tag == "redHP")
        {
            if (damaged)
            {
                StartCoroutine(ExampleCoroutine());
                playerHealth = playerHealth - 1;
                UpdateHealth();
                soundmanager.PlaySound("hit");
            }           
            //Destroy(other.gameObject);
        }
        if (playerHealth < 3)
        {
            if (other.gameObject.tag == "healhp")
            {
                soundmanager.PlaySound("heal");
                playerHealth = playerHealth + 1;
                UpdateHealth();
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.tag == "redbutton")
        {
            //Debug.Log("แดง");
            redOrblue = 1;
            //Debug.Log(redOrblue);

        }
        if (other.gameObject.tag == "bluebutton")
        {
            //Debug.Log("น้ำเงิน");
            redOrblue = 2;
            //Debug.Log(redOrblue);
        }
        

        
    }
    //เส้นระยะ
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }
    //เลือด
    public void UpdateHealth()
    {
        if (playerHealth <= 0)
        {
            Debug.Log("ตาย");
            animator.SetBool("Death", true);

        }
        else if(playerHealth <= 3)
        {
            animator.SetBool("Death", false);
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth)
            {
                hearts[i].gameObject.SetActive(true);
                //hearts[i].color = Color.red;
            }
            else
            {
                hearts[i].gameObject.SetActive(false);
                //hearts[i].color = Color.black;
            }
        }
    }
    IEnumerator ExampleCoroutine()
    {
        
        damaged=false;
        yield return new WaitForSeconds(1);
        damaged = true;
       
    }
}
