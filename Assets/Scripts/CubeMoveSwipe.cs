using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeMoveSwipe : MonoBehaviour
{

    private Rigidbody2D body;
    private Animator anim;
    public TextMeshProUGUI movesText;

    public float minSwipeDistY;
    public float minSwipeDistX;
    private Vector2 startPos;

    public int moveSpeed = 18;

    public int moves = 0;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.touchCount > 0 && body.velocity == Vector2.zero)
        {
            touchDirection();
        }

        //let animator know when ther is a collision
        if (body.velocity == Vector2.zero)
        {
            anim.SetBool("HitSurface", true);
            anim.SetBool("Moving", false);
        }
        else
        {
            anim.SetBool("HitSurface", false);
            anim.SetBool("Moving", true);
        }

    }

    private void touchDirection()
    {
        Touch touch = Input.touches[0];
        switch (touch.phase)

        {

            case TouchPhase.Began:
                startPos = touch.position;
                break;

            case TouchPhase.Ended:
                float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

                moves++;
                movesText.SetText(moves.ToString());

                if (swipeDistVertical > minSwipeDistY)
                {
                    float swipeValue = Mathf.Sign(touch.position.y - startPos.y);

                    if (swipeValue > 0)//up swipe
                    {
                        anim.SetInteger("Horizontal", 0);
                        anim.SetInteger("Vertical", 1);
                        body.velocity = new Vector2(0, moveSpeed);
                    }
                    else if (swipeValue < 0)//down swipe
                    {
                        anim.SetInteger("Horizontal", 0);
                        anim.SetInteger("Vertical", -1);
                        body.velocity = new Vector2(0, -moveSpeed); }
                }

                float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;

                if (swipeDistHorizontal > minSwipeDistX)
                {
                    float swipeValue = Mathf.Sign(touch.position.x - startPos.x);

                    if (swipeValue > 0)//right swipe
                    {
                        anim.SetInteger("Horizontal", 1);
                        anim.SetInteger("Vertical", 0);
                        body.velocity = new Vector2(moveSpeed, 0); }
                    else if (swipeValue < 0)//left swipe
                    {
                        anim.SetInteger("Horizontal", -1);
                        anim.SetInteger("Vertical", 0);
                        body.velocity = new Vector2(-moveSpeed, 0); }
                }
                break;
        }
    }
}
