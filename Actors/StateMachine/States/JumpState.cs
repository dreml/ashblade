using Godot;

[GlobalClass]
public partial class JumpState : State
{
  public override void Enter()
  {
    GD.Print("Entering Jump state");
    _physics.Jump();
  }

  public override void Exit() { }

  public override void Process(double delta)
  {
    if (_owner.IsOnFloor()) {
      _stateMachine.SwitchState("Idle");
    }
  }
}
