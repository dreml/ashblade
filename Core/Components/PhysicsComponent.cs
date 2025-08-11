using Godot;

[GlobalClass]
public partial class PhysicsComponent : Component
{
  [Export]
  private float _speed = 400.0f;
  [Export]
  private float _jumpForce = 400.0f;

  private int _moveDirection = 0;
  private float _gravity = (float)ProjectSettings.GetSetting("physics/2d/default_gravity");

  public override void _Process(double delta)
  {
    Vector2 velocity = OwnerCharacter.Velocity;

    velocity.X = _moveDirection * _speed;
    if (!OwnerCharacter.IsOnFloor()) {
      velocity.Y += _gravity * (float)delta;
    }

    ChangeOwnerVelocity(velocity);
    OwnerCharacter.MoveAndSlide();
  }

  public void SetMoveDirection(int direction)
  {
    _moveDirection = direction;
  }

  public void Jump()
  {
    if (!OwnerCharacter.IsOnFloor()) return;

    ChangeOwnerVelocity(OwnerCharacter.Velocity with { Y = -1 * _jumpForce });
  }

  public bool IsMoving()
  {
    return OwnerCharacter.Velocity.X != 0;
  }

  private void ChangeOwnerVelocity(Vector2 velocity)
  {
    OwnerCharacter.Velocity = velocity;
  }
}