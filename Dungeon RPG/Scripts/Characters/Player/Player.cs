using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer animPlayerNode;
    [Export] public Sprite3D sprite3DNode;
    [Export] public StateMachine stateMachineNode;

    public Vector2 direction = new();

    public override void _Input(InputEvent @event)
    {
        direction = Input.GetVector(
            GameConstants.INPUT_MOVELEFT,
            GameConstants.INPUT_MOVERIGHT,
            GameConstants.INPUT_MOVEFORWARD,
            GameConstants.INPUT_MOVEBACKWARD
        );
    }

    public void Flip()
    {
        bool isNotMovingHorizontally = Velocity.X == 0;

        if (isNotMovingHorizontally) { return; }
        
        bool isMovingLeft = Velocity.X < 0;
        sprite3DNode.FlipH = isMovingLeft;
    }
}
