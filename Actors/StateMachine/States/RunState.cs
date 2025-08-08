using Godot;

[GlobalClass]
public partial class RunState : State
{
  public override void Enter()
  {
    GD.Print("Entering Run state");
    _animPlayer.Play("Run");
  }

  public override void Exit() { }

  public override void Process(double delta)
  {
    if (_controller.MoveDirection == 0) {
      _stateMachine.SwitchState("Idle");
    } else {
      _sprite.FlipH = _controller.MoveDirection < 0;
    }

    if (_controller.WantsToJump) {
      _stateMachine.SwitchState("Jump");
    }
  }
}
