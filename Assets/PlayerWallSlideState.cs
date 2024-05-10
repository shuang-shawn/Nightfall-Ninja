using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        Debug.Log("enter wall slide");
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (yInput < 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);

        } else
        {
            rb.velocity = new Vector2(0, rb.velocity.y * .7f);
        }


        if (xInput != 0 && xInput != player.facingDir)
        {
            stateMachine.ChangeState(player.airState);
        }

        if (player.IsGroundDetected() && rb.velocity.y ==0)
        {
            Debug.Log("inside wallslide, moving to idle");
           stateMachine.ChangeState(player.idleState);
        }
    }
}
