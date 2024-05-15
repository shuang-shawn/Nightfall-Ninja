using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = player.dashDuration;
    }

    public override void Exit()
    {
        base.Exit();

        player.SetVelocity(0, rb.velocity.y);
    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(player.dashSpeed * player.dashDir, 0);

        Debug.Log("doing dash");

        if (player.isWallDetected() && !player.IsGroundDetected())
        {
            stateMachine.ChangeState(player.wallSlide);
        }

        if (stateTimer < 0)
        {
            if(!player.IsGroundDetected())
            {
                Debug.Log("going into falling state");
                stateMachine.ChangeState(player.airState);
            } else
            {
                Debug.Log("going into idle state after dash");
                stateMachine.ChangeState(player.idleState);
            }
            
        }
    }
}
