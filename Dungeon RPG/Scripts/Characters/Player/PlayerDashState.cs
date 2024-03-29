using Godot;
using System;

public partial class PlayerDashState : PlayerState
{
    [Export] private Timer dashTimerNode;
    [Export(PropertyHint.Range, "0,20,0.1")] private float dashSpeed = 10;

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
        characterNode.StateMachineNode.SwitchState<PlayerIdleState>();
        characterNode.Velocity = Vector3.Zero;
    }

    protected override void EnterState()
    {
        characterNode.AnimPlayerNode.Play(GameConstants.ANIM_DASH);
        characterNode.Velocity = new(
            characterNode.direction.X, 0, characterNode.direction.Y
        );

        if (characterNode.direction == Vector2.Zero) {
            characterNode.Velocity = characterNode.Sprite3DNode.FlipH ? Vector3.Left : Vector3.Right;
        }

        characterNode.Velocity *= dashSpeed;
        dashTimerNode.Start();
    }

}
