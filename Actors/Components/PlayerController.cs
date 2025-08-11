using Godot;

[GlobalClass]
public partial class PlayerController : BaseController
{
  public override void _UnhandledInput(InputEvent @event)
  {
    if (!CanMove) {
      return;
    }

    if (Input.IsActionJustPressed("jump") && OwnerCharacter.IsOnFloor()) {
      _jumpRequestTime = Time.GetTicksMsec();
      StateMachine.SwitchState("Jump");
    }

    MoveDirection = (int)Input.GetAxis("left", "right");
    Physics.SetMoveDirection(MoveDirection);
  }
}
