using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    float Speed = 3.0f;

    private float HitBySpeed = 4.0f;
    public string PlayerNum; ///P(x)
    private bool HasBeenHitInLast5s = false;
    private float HasBeenHitTimer = 0.0f;
    private float HitByHorizontalAxis;
    private float HitByVerticalAxis;
    private float ThisHorizontalAxis;
    private float ThisVerticalAxis;
    private Animator animator;

    [SerializeField]
    GameManager Manager;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update () {
        if (Manager.GetComponent<GameManager>().PlayersAlive == 1)
        {
            Manager.GetComponent<GameManager>().FirstPlace = PlayerNum;
            Manager.GetComponent<GameManager>().CheckIfWon();
        }
        //handles when a player is hit by the belly of another 
        if (HasBeenHitInLast5s)
        {
            if(HasBeenHitTimer <= 0)
            {
                HasBeenHitInLast5s = false;
            }
            else
            {
                HasBeenHitTimer -= Time.deltaTime;
                transform.position += new Vector3(HitByHorizontalAxis * Time.deltaTime * HitBySpeed, HitByVerticalAxis * Time.deltaTime * HitBySpeed);
            } 
        }
        //movement handling
        ThisHorizontalAxis = Input.GetAxis(PlayerNum + "Horizontal");
        ThisVerticalAxis = Input.GetAxis(PlayerNum + "Vertical");

        ThisVerticalAxis = -ThisVerticalAxis;
        if (Manager.GetComponent<GameManager>().GameState == "Playing")
        {
            transform.position += new Vector3(ThisHorizontalAxis * Time.deltaTime * Speed, ThisVerticalAxis * Time.deltaTime * Speed);
        }

        //Rotation handling
        float RotateAxis = Input.GetAxis(PlayerNum + "Rotate");
        RotateAxis = -RotateAxis;
        if (Manager.GetComponent<GameManager>().GameState == "Playing")
        {
            transform.Rotate(0, 0, RotateAxis * Speed);
        }

        //animation
        if ((ThisHorizontalAxis != 0 || ThisVerticalAxis != 0) && RotateAxis == 0)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }
    public void Hit(float HorizontalAxis, float VerticalAxis, int HitBy) ///hitby 1 for player 2 for obstacle
    {
        HasBeenHitInLast5s = true;
        HasBeenHitTimer = 1;
        if (HitBy == 1)
        {
            HitByHorizontalAxis = HorizontalAxis;
            HitByVerticalAxis = -VerticalAxis;
        }
        else if (HitBy == 2)
        {
            if(Math.Abs(HitByHorizontalAxis) > Math.Abs(ThisHorizontalAxis))
            {
                HitByHorizontalAxis = -HitByHorizontalAxis;
            }
            else
            {
                HitByHorizontalAxis = -ThisHorizontalAxis;
            }
            if(Math.Abs(HitByVerticalAxis) > Math.Abs(ThisVerticalAxis))
            {
                HitByVerticalAxis = -HitByVerticalAxis;
            }
            else
            {
                HitByVerticalAxis = -ThisVerticalAxis;
            }
        }
    }
}
