using Godot;
using System;

[GlobalClass]
public partial class PlayerController : Node
{
  [Export]
  private PhysicsComponent _physics;

  public int Direction { get; private set; } = 0;

  private CharacterBody2D _owner;

  public override void _Ready()
  {
    if (_physics == null) {
      GD.PrintErr("No PhysicsComponent in PlayerController");
    }

    _owner = Owner as CharacterBody2D;
  }

  public override void _UnhandledInput(InputEvent @event)
  {
    Direction = 0;
    if (Input.IsActionPressed("left")) {
      Direction -= 1;
    }
    if (Input.IsActionPressed("right")) {
      Direction += 1;
    }

    _physics.SetHorizontalDirection(Direction);

    if (Input.IsActionJustPressed("jump") && _owner.IsOnFloor()) {
      _physics.Jump();
    }
  }
}
