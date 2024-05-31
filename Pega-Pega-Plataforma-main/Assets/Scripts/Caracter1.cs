using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caracter1 : MonoBehaviour
{
    public float Speed;
    public string test;
    public float JumpForce;
    private Rigidbody2D rig;

    private Animator anim;
    public bool isJumping;
    public bool doubleJump;

    void Start()
    {
       rig = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.D))
        {
            movement = new Vector3(1f, 0f, 0f);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            anim.SetBool("Walk", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movement = new Vector3(-1f, 0f, 0f);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        transform.position += movement * Time.deltaTime * Speed;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                anim.SetBool("Jump", true);
            }
            else if (doubleJump)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = false;
            anim.SetBool("Jump", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }
}
