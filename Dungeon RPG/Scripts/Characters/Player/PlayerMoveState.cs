using Godot;
using System;

public partial class PlayerMoveState : Node
{
    public override void _Notification(int what)
    {
        base._Notification(what);

        if (what == 5001)
        {
            Player characterNode = GetOwner<Player>();
            characterNode.animPlayerNode.Play(GameConstants.ANIM_MOVE);
        }
    }
}
