using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveit : MonoBehaviour
{
    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = false;
    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    public Transform groundCheck;

    Vector3 startPostion;

    private const float slowMotion = 1;

    private bool grounded = false;
  
    private Rigidbody2D rb2d;


    // Use this for initialization
    void Awake()
    {
  
        rb2d = GetComponent<Rigidbody2D>();
        startPostion = gameObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        

        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        if (jump)
        {
         
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            maxSpeed = slowMotion;

        }

        else
        {
            maxSpeed = 5f;
        }

        if (Input.GetKey(KeyCode.Space))
            gameObject.transform.position = startPostion;

    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

