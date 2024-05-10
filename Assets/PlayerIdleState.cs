using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        rb.velocity = Vector2.zero;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(xInput == player.facingDir && player.isWallDetected())
        {
            Debug.Log("realy return from idle staet");
            return;
        }

        else if (xInput != 0)
        {
            Debug.Log("somehow still entereing move");
            stateMachine.ChangeState(player.moveState);
        }
        
    }
}
