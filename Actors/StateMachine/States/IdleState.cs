using Godot;

[GlobalClass]
public partial class IdleState : State
{
  public override void Enter()
  {
    GD.Print("Entering Idle state");
    _animPlayer.Play("Idle");
  }

  public override void Exit() { }

  public override void Process(double delta)
  {
    if (_controller.MoveDirection != 0) {
      _stateMachine.SwitchState("Run");
    }
    if (_controller.WantsToJump) {
      _stateMachine.SwitchState("Jump");
    }
  }
}
