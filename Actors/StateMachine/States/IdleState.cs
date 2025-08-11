using Godot;

[GlobalClass]
public partial class IdleState : State
{
  public override void Enter()
  {
    GD.Print("Entering Idle state");
    AnimPlayer.Play("Idle");
  }

  public override void Exit() { }

  public override void Process(double delta)
  {
    if (Controller.MoveDirection != 0) {
      StateMachine.SwitchState("Run");
    }
    if (Controller.WantsToJump) {
      StateMachine.SwitchState("Jump");
    }
  }
}
