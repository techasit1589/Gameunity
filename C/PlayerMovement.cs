using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //วิ่ง
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

    //หลอดเลือด
    public int healtbar = 3;
    public Text healthText;

    //ขึ้นบรรได
    public float distance;
    public LayerMask whatIsLadder;
    private bool isClimbing;
    private float inputVertical;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;

    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();   
        animator.SetBool("Death", false);
    }

    private void Update()
    {
        //หลอดเลือด
        healthText.text = "Health: " + healtbar;
        if(healtbar<=0)
        {
            animator.SetBool("Death", true);
        }
        //พุ่ง
        if (isDashing)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            animator.SetBool("Jump", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            animator.SetBool("Jump", false);
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
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

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

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
        if (other.gameObject.tag == "deathZone")
        {
            gameObject.transform.position = new Vector2(-4.27f, 1.85f);
            //healtbar = 0;
        }
        if (other.gameObject.tag == "redHP")
        {
            healtbar = healtbar-1;
            //sprite.color = new Color (1, 0, 0, 1);  
        }
        // else
        // {
        //     sprite.color = new Color (255, 255, 255, 255);
        // }
        if (other.gameObject.tag == "healhp")
        {
            healtbar = healtbar+1;
            Destroy(other.gameObject);
        }
    }
}
