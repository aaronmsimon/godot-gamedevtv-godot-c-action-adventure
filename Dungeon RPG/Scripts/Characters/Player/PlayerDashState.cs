using Godot;
using System;

public partial class PlayerDashState : PlayerState
{
    [Export] private Timer dashTimerNode;
    [Export] private float speed = 10;

    public override void _Ready()
    {
        base._Ready();
        
        dashTimerNode.Timeout += HandleDashTimeout;
    }

    public override void _PhysicsProcess(double delta)
    {
        characterNode.MoveAndSlide();
        characterNode.Flip();
    }

    private void HandleDashTimeout()
    {
        characterNode.stateMachineNode.SwitchState<PlayerIdleState>();
        characterNode.Velocity = Vector3.Zero;
    }

    protected override void EnterState()
    {
        characterNode.animPlayerNode.Play(GameConstants.ANIM_DASH);
        characterNode.Velocity = new(
            characterNode.direction.X, 0, characterNode.direction.Y
        );

        if (characterNode.direction == Vector2.Zero) {
            characterNode.Velocity = characterNode.sprite3DNode.FlipH ? Vector3.Left : Vector3.Right;
        }

        characterNode.Velocity *= speed;
        dashTimerNode.Start();
    }

}
