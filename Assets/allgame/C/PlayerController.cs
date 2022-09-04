using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //dash
    private bool canDash=true;
    private bool isDashing;    
    private float dasgingPower = 5f;
    private float dasgingTime = 0.2f;
    private float dasgingCooldown = 1f;

    [SerializeField] private TrailRenderer tr;

    // player
    public float speed = 1f;
    public float jumpSpeed = 9f;
    public float maxSpeed = 10f;
    public float jumpPower = 25f;
    public float grounded;
    public float jumpRate = 1f;
    public float nextJumpPress = 0.0f;
    //
    [SerializeField] private LayerMask platformLayerMask;
    public bool isNotsky;
    //public bool aground;
    private Rigidbody2D rigidBody2D;
    private Physics2D physics2D;
    private BoxCollider2D bcol;
    Animator animator;
    public int healtbar = 100;
    public Text healthText;
    //ขึ้นบรรได
    public float distance;
    public LayerMask whatIsLadder;
    private bool isClimbing;
    private float inputVertical;
    //สี
    SpriteRenderer sprite;

    void Start()
    {
        rigidBody2D = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
        bcol = this.gameObject.GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(isDashing)
        {
            return;
        }
        //dash
        if(Input.GetKeyDown(KeyCode.LeftShift)&&canDash)
        {
            StartCoroutine(Dash());
        }
        //หลอดเลือด
        healthText.text = "Health: " + healtbar;
        //if (healtbar <= 0)
        //{
        //    healtbar = 0;
        //    animator.SetTrigger("Death");
        //}
        animator.SetBool("Grounded", true);
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        //วิ่ง
        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }
        else if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        //โดด
        //if (aground() && Input.GetButtonDown("Jump") && Time.time > nextJumpPress)
        if (Input.GetButtonDown("Jump") && Time.time > nextJumpPress)
        {
            //animator.SetBool("Grounded", false);
            animator.SetBool("Jump", true);
            nextJumpPress = Time.time + jumpRate;
            rigidBody2D.AddForce(jumpSpeed * (Vector2.up * jumpPower));
        }
        else
        {
            //animator.SetBool("Grounded", true);
            animator.SetBool("Jump", false);
        }

        //ม้วนตัว
        // if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time > nextJumpPress && Input.GetAxis("Horizontal") < -0.1f)
        // {
        //     //animator.SetBool("Jump", true);
        //     Debug.Log("พุ่ง");
        //     nextJumpPress = Time.time + jumpRate;
        //     rigidBody2D.AddForce(jumpSpeed * (Vector2.left * 50f));
        // }else if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time > nextJumpPress && Input.GetAxis("Horizontal") > 0.1f){
        //     Debug.Log("พุ่ง");
        //     nextJumpPress = Time.time + jumpRate;
        //     rigidBody2D.AddForce(jumpSpeed * (Vector2.right * 50f));
        // }
        // if (Input.GetKeyDown(KeyCode.C))
        // {
        //     animator.SetBool("Crouch", true);
        // }
        // if (Input.GetKeyUp(KeyCode.C))
        // {
        //     animator.SetBool("Crouch", false);
        // }
        // else
        // {
        //     animator.SetBool("Crouch", false);
        // }
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
            rigidBody2D.velocity = new Vector2(0.0f, inputVertical * speed);
            rigidBody2D.gravityScale = 0;
        }
        else
        {
            animator.SetBool("Climb", false);
            rigidBody2D.gravityScale = 1;
        }
        
    }
    private void FixedUpdate()
    {
        if(isDashing)
        {
            return;
        }
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
            healtbar = healtbar-20;
            //sprite.color = new Color (1, 0, 0, 1);  
        }
        // else
        // {
        //     sprite.color = new Color (255, 255, 255, 255);
        // }
        if (other.gameObject.tag == "healhp")
        {
            healtbar = healtbar+20;
            Destroy(other.gameObject);
        }
    }
    //เช็คอยู่บนพื้นหรือไม่
    private bool aground()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(bcol.bounds.center, bcol.bounds.size, 0f, Vector2.down, 0.09f, platformLayerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
            isNotsky = true;
        }
        else
        {
            rayColor = Color.red;
            isNotsky = false;
        }
        Debug.DrawRay(bcol.bounds.center + new Vector3(bcol.bounds.extents.x, 0), Vector2.down * (bcol.bounds.extents.y + 0.09f), rayColor);
        Debug.DrawRay(bcol.bounds.center - new Vector3(bcol.bounds.extents.x, 0), Vector2.down * (bcol.bounds.extents.y + 0.09f), rayColor);
        Debug.DrawRay(bcol.bounds.center - new Vector3(bcol.bounds.extents.x, bcol.bounds.extents.y, 0.09f), Vector2.right * (bcol.bounds.extents.y), rayColor);
        return raycastHit.collider != null;
    }

    private IEnumerator Dash()
    {
        canDash=false;
        isDashing=true;
        float originalGravity=rigidBody2D.gravityScale;
        rigidBody2D.gravityScale=0f;
        rigidBody2D.velocity=new Vector2(transform.localScale.x*dasgingPower,0f);
        tr.emitting=true;
        yield return new WaitForSeconds(dasgingTime);
        tr.emitting=false;
        rigidBody2D.gravityScale=originalGravity;
        isDashing=false;
        yield return new WaitForSeconds(dasgingCooldown);
        canDash = true;
    }

}
