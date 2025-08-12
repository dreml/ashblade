using Godot;

[GlobalClass]
public partial class PlayerController : BaseController
{
  public override void _UnhandledInput(InputEvent @event)
  {
    if (!CanMove) {
      return;
    }

    if (Input.IsActionJustPressed("jump")) {
      _jumpRequestTime = Time.GetTicksMsec();
    }

    MoveDirection = (int)Input.GetAxis("left", "right");
    Physics.SetMoveDirection(MoveDirection);
  }
}
