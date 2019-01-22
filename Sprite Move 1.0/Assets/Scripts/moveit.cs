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

    //Marks the starting postition
    Vector3 startPostion;

    //Slowed speed variable
    private const float slowMotion = 1;

    private bool grounded = false;

    //Rigid body for sprite
    private Rigidbody2D rb2d;


    // Use this for initialization
    void Awake()
    {
        //Gets the rigidbody of the 2d sprite attached to script
        rb2d = GetComponent<Rigidbody2D>();
        startPostion = gameObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        //Tried to impliment a jumping physic but it did not work
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
    }
    //Goes after the update
    void FixedUpdate()
    {
        //Allows player to use arrow keys or 'a'/'d' keys for movement
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
        //Slow the movement to 1 frame rather than 5 with left shift key
        if (Input.GetKey(KeyCode.LeftShift))
        {
            maxSpeed = slowMotion;

        }
        //Resets back to normal game speed instead of slowed
        else
        {
            maxSpeed = 5f;
        }
        //Resets game object to starting position
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

