using Godot;
using System;

[GlobalClass]
public partial class PhysicsComponent : Node
{
  [Export]
  private float _speed = 400.0f;
  [Export]
  private float _jumpForce = 400.0f;

  private CharacterBody2D _owner;
  private float _direction = 0;
  private float _gravity = (float)ProjectSettings.GetSetting("physics/2d/default_gravity");

  public override void _Ready()
  {
    _owner = Owner as CharacterBody2D;
  }

  public override void _Process(double delta)
  {
    Vector2 velocity = _owner.Velocity;

    velocity.X = _direction * _speed;
    if (!_owner.IsOnFloor()) {
      velocity.Y += _gravity * (float)delta;
    }

    ChangeOwnerVelocity(velocity);
    _owner.MoveAndSlide();
  }

  public void SetHorizontalDirection(int direction)
  {
    _direction = direction;
  }

  public void Jump()
  {
    if (!_owner.IsOnFloor()) return;

    ChangeOwnerVelocity(_owner.Velocity with { Y = -1 * _jumpForce });
  }

  private void ChangeOwnerVelocity(Vector2 velocity)
  {
    _owner.Velocity = velocity;
  }
}
