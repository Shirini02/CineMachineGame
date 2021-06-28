using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerspeed, playerjumpForce, playerRadius;
    Rigidbody2D rb;
    bool facingRight;
    public bool isGrounded = true;
    public LayerMask layermask;
    public int jumps, maxnumberofjumps;
    public Transform groundCheck;
    float xinput;
    Score scoremanager;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;

    }
    void Start()
    {
        jumps = maxnumberofjumps;
        scoremanager = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            jumps = maxnumberofjumps;

        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, playerRadius, layermask);
        xinput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xinput * playerspeed, rb.velocity.y);

        if (facingRight == false && xinput > 0)
        {
            Flip();
        }
        else if (facingRight == true && xinput < 0)
        {
            Flip();
        }
        if (Input.GetButtonDown("Jump") && jumps > 0)
        {
            rb.velocity = Vector2.up * playerjumpForce;
            maxnumberofjumps -= 1;
        }
        if (Input.GetButtonDown("Jump") && jumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * playerjumpForce;

        }



    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180.0f, 0);
    }
    public void superjump()
    {
        rb.velocity = Vector2.up * playerjumpForce * 2;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coins")
        {

            Destroy(collision.gameObject);
            scoremanager.IncrementScore();
        }
    }
}
