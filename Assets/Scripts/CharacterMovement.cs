using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Vector2 moveVector;
    public Transform groundCheck;
    public LayerMask Ground;
    public Animator animator;

    public float speed = 8f;
    public float jumpForce = 7f;
    public float checkRadius = 0.15f;
    public bool onGround;

    Rigidbody2D rb;
    SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Walk();
        Jump();
        CheckingGround();
        Anim();
    }

    void Anim()
    {
        animator.SetFloat("Speed", Mathf.Abs(moveVector.x));
        animator.SetBool("isJump", !onGround);
    }

    void Walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");
        //rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
        transform.position += new Vector3(moveVector.x, 0, 0) * speed * Time.deltaTime;

        if (moveVector.x > 0)
            sr.flipX = false;

        if (moveVector.x < 0)
            sr.flipX = true;
    }
    void Jump()
    {
        if (moveVector.y < 0)
        {
            Physics2D.IgnoreLayerCollision(6, 7, true);
            Invoke("IgnoreLayerOff", 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, Ground);
    }

    void IgnoreLayerOff()
    {
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }
}