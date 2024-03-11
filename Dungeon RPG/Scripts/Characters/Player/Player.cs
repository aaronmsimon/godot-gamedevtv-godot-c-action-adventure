using Godot;
using System;

public partial class Player : CharacterBody3D
{
    public override void _PhysicsProcess(double delta)
    {
        // base._PhysicsProcess(delta);
        GD.Print("Player physics process!");
    }

    public override void _Input(InputEvent @event)
    {
        // base._Input(@event);
        GD.Print("Player input!");
    }
}
