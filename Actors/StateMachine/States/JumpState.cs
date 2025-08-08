using Godot;

[GlobalClass]
public partial class JumpState : State
{
  public override void Enter()
  {
    GD.Print("Entering Jump state");
    if (!_controller.WantsToJump) return;

    _physics.Jump();
    _controller.ConsumeJumpInput();
  }

  public override void Exit() { }

  public override void Process(double delta)
  {
    var isMoving = _controller.MoveDirection != 0;

    if (_owner.IsOnFloor()) {
      _stateMachine.SwitchState(isMoving ? "Run" : "Idle");
    }

    if (isMoving) {
      _sprite.FlipH = _controller.MoveDirection < 0;
    }
  }
}
