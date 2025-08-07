using Godot;
using System;

public partial class Player : CharacterBody2D
{
  [Export]
  private float _speed = 400.0f;

  [Export]
  private float _jumpForce = -400.0f;

  private float _gravity = (float)ProjectSettings.GetSetting("physics/2d/default_gravity");

  private Sprite2D _sprite;
  private AnimationPlayer _animPlayer;

  public override void _Ready()
  {
    _sprite = GetNode<Sprite2D>("Sprite");
    _animPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
  }

  public override void _PhysicsProcess(double delta)
  {
    Vector2 velocity = Velocity;

    int direction = 0;
    if (Input.IsActionPressed("left")) {
      direction -= 1;
    }
    if (Input.IsActionPressed("right")) {
      direction += 1;
    }

    velocity.X = direction * _speed;
    if (!IsOnFloor()) {
      velocity.Y += _gravity * (float)delta;
    }

    if (Input.IsActionJustPressed("jump") && IsOnFloor()) {
      velocity.Y = _jumpForce;
    }

    if (direction != 0) {
      _animPlayer.Play("Run");
      _sprite.FlipH = direction < 0;
    } else {
      _animPlayer.Play("Idle");
    }

    Velocity = velocity;
    MoveAndSlide();
  }
}
