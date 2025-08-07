using Godot;
using System;

[GlobalClass]
public partial class PlayerController : Node
{
  [Export]
  private PhysicsComponent _physics;
  [Export]
  private StateMachine _stateMachine;

  public int Direction { get; private set; }
  public bool CanMove = true;

  private CharacterBody2D _owner;

  public override void _Ready()
  {
    if (_physics == null) {
      GD.PrintErr("No PhysicsComponent in PlayerController");
    }
    if (_stateMachine == null) {
      GD.PrintErr("No StateMachine in PlayerController");
    }

    _owner = Owner as CharacterBody2D;
  }

  public override void _UnhandledInput(InputEvent @event)
  {
    if (!CanMove) return;

    if (Input.IsActionJustPressed("jump") && _owner.IsOnFloor()) {
      _stateMachine.SwitchState("Jump");
    }

    Direction = (int)Input.GetAxis("left", "right");
    _physics.SetHorizontalDirection(Direction);

    if (Direction != 0) {
      _stateMachine.SwitchState("Run");
    }
  }

  public bool IsMoving()
  {
    return _owner.Velocity.X != 0;
  }
}
