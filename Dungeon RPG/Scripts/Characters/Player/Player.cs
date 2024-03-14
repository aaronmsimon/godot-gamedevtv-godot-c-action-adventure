using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] private AnimationPlayer animPlayerNode;
    [Export] private Sprite3D sprite3DNode;

    private Vector2 direction = new();

    public override void _Ready()
    {
        animPlayerNode.Play(GameConstants.ANIM_IDLE);
    }

    public override void _PhysicsProcess(double delta)
    {
        Velocity = new(direction.X, 0, direction.Y);
        Velocity *= 5;

        MoveAndSlide();
        Flip();
    }

    public override void _Input(InputEvent @event)
    {
        direction = Input.GetVector(
            GameConstants.INPUT_MOVELEFT,
            GameConstants.INPUT_MOVERIGHT,
            GameConstants.INPUT_MOVEFORWARD,
            GameConstants.INPUT_MOVEBACKWARD
        );

        if (direction == Vector2.Zero)
        {
            animPlayerNode.Play(GameConstants.ANIM_IDLE);
        }
        else
        {
            animPlayerNode.Play(GameConstants.ANIM_MOVE);
        }
    }

    private void Flip()
    {
        bool isNotMovingHorizontally = Velocity.X == 0;

        if (isNotMovingHorizontally) {return;}
        
        bool isMovingLeft = Velocity.X < 0;
        sprite3DNode.FlipH = isMovingLeft;
    }
}
