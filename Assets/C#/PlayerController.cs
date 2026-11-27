using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed; // how fast the character moves
    public float jumpHeight; // how high the character jumps

    public KeyCode Spacebar; // jump key (set to Space in the Inspector)
    public KeyCode L; // left movement key (set to Left Arrow in the Inspector)
    public KeyCode R; // right movement key (set to Right Arrow in the Inspector)

    public Transform groundCheck; // invisible point at the player's feet
    public float groundCheckRadius; // size of the circle around the feet
    public LayerMask whatIsGround; // what counts as ground (set to the Ground layer)
    private bool grounded; // true if the character is standing on solid ground

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    [SerializeField] private Animator anim; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Spacebar) && grounded) // When user presses the space button ONCE
        {
            Jump();
        }

        if (Input.GetKey(L)) // When user presses the left arrow button
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            if(sr != null) sr.flipX = true;
            // moves left along the x-axis without disrupting the jump
        }

        else if (Input.GetKey(R)) // When user presses the right arrow button
        {
           rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            // moves right along the x-axis without disrupting the jump
            if(sr != null) sr.flipX = false;
        }
        else
        {
            if(grounded) rb.velocity = new Vector2(0f, rb.velocity.y);

            else
                rb.velocity = new Vector2(rb.velocity.x * 0.98f, rb.velocity.y);
        }
        //  Exercise #09: vertical velocity -> Jump/Fall blend tree
        // anim.SetFloat("Height", rb.velocity.y);

        // Exercise #09: grounded state -> enter/exit the jumping blend tree
        anim.SetBool("Grounded", grounded);

        if(Input.GetAxis("Horizontal") != 0){
             anim.SetBool("IsRunning",true);
        }
        else{
             anim.SetBool("IsRunning",false);
        }
    }

    void FixedUpdate()
    {
        // checks if the groundCheck circle overlaps the ground's collider
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpHeight);
        // jumps vertically along the y-axis without disrupting horizontal movement
    }
}