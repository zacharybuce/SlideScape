using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public Animator anim;

    private float horizontal;
    private float vertical;

    private const int moveSpeed = 12;

    public int moves = 0;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

            // Gives a value between -1 and 1
            //accepts input only if the character is static
        if (vertical == 0 && body.velocity == Vector2.zero)
        {
            horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        }
        if (horizontal == 0 && body.velocity == Vector2.zero)
        {
            vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        }

        move();

        //let animator know when ther is a collision
        if (body.velocity == Vector2.zero)
        {
            anim.SetBool("HitSurface", true);
            anim.SetBool("Moving", false);
        }
        else
        {
            anim.SetBool("HitSurface",false);
            anim.SetBool("Moving", true);
        }
        vertical = 0;
        horizontal = 0;
    }
    void Update()
    {
        if (Input.anyKeyDown)
        {
            moves++;
        }
    }
    //moves character constantly until a collision
    private void move()
    {
        //anim.SetBool("HitSurface", false);
        if (horizontal == 1)//move right
        {
            anim.SetInteger("Horizontal", 0);
            anim.SetInteger("Vertical", 0);
            body.velocity = new Vector2(moveSpeed, 0);
            anim.SetInteger("Horizontal", 1);

        }
        if (horizontal == -1)//move left
        {
            anim.SetInteger("Horizontal", 0);
            anim.SetInteger("Vertical", 0);
            body.velocity = new Vector2(-moveSpeed, 0);
            anim.SetInteger("Horizontal", -1);


        }

        if (vertical == 1)//move up
        {
            anim.SetInteger("Horizontal", 0);
            anim.SetInteger("Vertical", 0);
            body.velocity = new Vector2(0, moveSpeed);
            anim.SetInteger("Vertical", 1);

        }

        if (vertical == -1)//move down
        {
            anim.SetInteger("Horizontal", 0);
            anim.SetInteger("Vertical", 0);
            body.velocity = new Vector2(0, -moveSpeed);
            anim.SetInteger("Vertical", -1);
        }
    }
}